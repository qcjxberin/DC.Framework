﻿using System;
using System.Threading.Tasks;
using DotNetCore.CAP;
using Ding.Datas.Transactions;
using Ding.Logs;
using Ding.Logs.Extensions;

namespace Ding.Events.Cap {
    /// <summary>
    /// Cap消息事件总线
    /// </summary>
    public class MessageEventBus : IMessageEventBus {
        /// <summary>
        /// 初始化Cap消息事件总线
        /// </summary>
        /// <param name="publisher">事件发布器</param>
        /// <param name="transactionActionManager">事务操作管理器</param>
        public MessageEventBus( ICapPublisher publisher, ITransactionActionManager transactionActionManager ) {
            Publisher = publisher ?? throw new ArgumentNullException( nameof( publisher ) );
            TransactionActionManager = transactionActionManager ?? throw new ArgumentNullException( nameof( transactionActionManager ) );
        }

        /// <summary>
        /// 事件发布器
        /// </summary>
        public ICapPublisher Publisher { get; set; }
        /// <summary>
        /// 事务操作管理器
        /// </summary>
        public ITransactionActionManager TransactionActionManager { get; set; }

        /// <summary>
        /// 发布事件
        /// </summary>
        /// <typeparam name="TEvent">事件类型</typeparam>
        /// <param name="event">事件</param>
        public async Task PublishAsync<TEvent>( TEvent @event ) where TEvent : IMessageEvent {
            await PublishAsync( @event.Name, @event.Data, @event.Callback, @event.Send );
        }

        /// <summary>
        /// 发布事件
        /// </summary>
        /// <param name="name">消息名称</param>
        /// <param name="data">事件数据</param>
        /// <param name="callback">回调名称</param>
        /// <param name="send">是否立即发送消息</param>
        public async Task PublishAsync( string name, object data, string callback = null, bool send = false ) {
            if( send ) {
                Publisher.Transaction.AutoCommit = true;
                await Publish( name, data, callback );
                return;
            }
            TransactionActionManager.Register( async transaction => {
                Publisher.Transaction.DbTransaction = transaction;
                Publisher.Transaction.AutoCommit = false;
                await Publish( name, data, callback );
            } );
        }

        /// <summary>
        /// 发布事件
        /// </summary>
        private async Task Publish( string name, object data, string callback ) {
            await Publisher.PublishAsync( name, data, callback );
            WriteLog( name );
        }

        /// <summary>
        /// 写日志
        /// </summary>
        private void WriteLog( string name ) {
            var log = GetLog();
            if( log.IsDebugEnabled == false )
                return;
            log.Caption( "Cap发送事件完成" )
                .Content( $"消息名称:{name}" )
                .Debug();
        }

        /// <summary>
        /// 获取日志
        /// </summary>
        private ILog GetLog() {
            try {
                return Log.GetLog( this );
            }
            catch {
                return Log.Null;
            }
        }
    }
}
