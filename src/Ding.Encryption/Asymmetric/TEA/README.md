###  **使用方法：** 

```
txtTEAKey.Text = TEA.GenerateTeaKey();

txtEncryptedText.Text = TEA.Encrypt(txtPlainText.Text, txtTEAKey.Text);

txtPlainText.Text = TEA.Decrypt(txtEncryptedText.Text, txtTEAKey.Text);

```
