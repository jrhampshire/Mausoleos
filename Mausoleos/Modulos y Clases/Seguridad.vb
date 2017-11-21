
Imports System
Imports System.Text
Imports System.Security
Imports System.Security.Cryptography
Imports System.IO

Public Class Seguridad
    Function Crear_Hash(ByVal Cadena_Inicial As String) As String
        Dim CadenaUTF8 As Byte()
        Dim tmpHash() As Byte
        Dim Digestion As String
        Dim Ruta As String = System.AppDomain.CurrentDomain.BaseDirectory()

        'convierte en UTF8
        CadenaUTF8 = System.Text.Encoding.UTF8.GetBytes(Cadena_Inicial)

        'crea el hash
        tmpHash = New MD5CryptoServiceProvider().ComputeHash(CadenaUTF8)
        ' lo pasa a una variable string mediante la funcion ByteArrayToString
        Digestion = UnicodeBytesToString(tmpHash)


        System.IO.File.WriteAllText(Ruta & "MD5.txt", Digestion, Encoding.UTF8)
        System.IO.File.WriteAllText(Ruta & "CadenaOriginal.txt", Cadena_Inicial, Encoding.UTF8)

        '///////////////////////////////////////
        '///////////////////////////////////////
        '///////////////////////////////////////
        ''///////////////////////////////////////
        Dim bytHash As Byte()
        Dim uEncode As New UnicodeEncoding()
        '///////////////////////////////////////
        'almacenar la cadena original en una matriz de bytes
        '///////////////////////////////////////
        Dim bytSource() As Byte = uEncode.GetBytes(Cadena_Inicial)
        Dim sha1 As New SHA1CryptoServiceProvider()
        '///////////////////////////////////////
        'Crear el Hash
        '///////////////////////////////////////
        bytHash = sha1.ComputeHash(bytSource)
        '///////////////////////////////////////
        'Devolver como una cadena codificada en base64
        '///////////////////////////////////////
        Return Convert.ToBase64String(bytHash)
    End Function
    Private Function UnicodeBytesToString(
    ByVal bytes() As Byte) As String

        Return System.Text.Encoding.Unicode.GetString(bytes)
    End Function
    Public Shared Function Encrypt(ByVal Data As String, ByVal Publickey As String) As RSAResult
        Try
            Dim ByteConverter As New UnicodeEncoding()
            Return Encrypt(ByteConverter.GetBytes(Data), Publickey)
        Catch ex As Exception
            Throw New Exception("Encrypt(String): " & ex.Message, ex)
        End Try
    End Function

    Public Shared Function Encrypt(ByVal Data() As Byte, ByVal Publickey As String) As RSAResult
        Try
            Dim RSA As System.Security.Cryptography.RSACryptoServiceProvider = New System.Security.Cryptography.RSACryptoServiceProvider()
            RSA.FromXmlString(Publickey)
            Return New RSAResult(RSAEncrypt(Data, RSA.ExportParameters(False), False))
        Catch ex As Exception
            Throw New Exception("Encrypt(Bytes): " & ex.Message, ex)
        End Try
    End Function

    Public Shared Function Decrypt(ByVal Data() As Byte, ByVal Privatekey As String) As RSAResult
        Try
            Dim RSA As System.Security.Cryptography.RSACryptoServiceProvider = New System.Security.Cryptography.RSACryptoServiceProvider()
            RSA.FromXmlString(Privatekey)
            Dim Result As New RSAResult(RSADecrypt(Data, RSA.ExportParameters(True), False))
            Return Result
        Catch ex As Exception
            Throw New Exception("Decrypt(): " & ex.Message, ex)
        End Try
    End Function

    Private Shared Function RSAEncrypt(ByVal DataToEncrypt() As Byte, ByVal RSAKeyInfo As RSAParameters, ByVal DoOAEPPadding As Boolean) As Byte()
        Try
            Dim encryptedData() As Byte
            Using RSA As New RSACryptoServiceProvider
                RSA.ImportParameters(RSAKeyInfo)
                encryptedData = RSA.Encrypt(DataToEncrypt, DoOAEPPadding)
            End Using
            Return encryptedData
        Catch e As CryptographicException
            Throw New Exception("RSAEncrypt(): " & e.Message, e)
        End Try
    End Function

    Private Shared Function RSADecrypt(ByVal DataToDecrypt() As Byte, ByVal RSAKeyInfo As RSAParameters, ByVal DoOAEPPadding As Boolean) As Byte()
        Try
            Dim decryptedData() As Byte
            Using RSA As New RSACryptoServiceProvider
                RSA.ImportParameters(RSAKeyInfo)
                decryptedData = RSA.Decrypt(DataToDecrypt, DoOAEPPadding)
            End Using
            Return decryptedData
        Catch e As CryptographicException
            Throw New Exception("RSADecrypt(): " & e.Message, e)
        End Try
    End Function
End Class

