﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.18408
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict Off
Option Explicit On

Imports System.Xml.Serialization

'
'This source code was auto-generated by xsd, Version=4.0.30319.33440.
'

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),  _
 System.SerializableAttribute(),  _
 System.Diagnostics.DebuggerStepThroughAttribute(),  _
 System.ComponentModel.DesignerCategoryAttribute("code"),  _
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=true, [Namespace]:="http://www.sat.gob.mx/TimbreFiscalDigital"),  _
 System.Xml.Serialization.XmlRootAttribute([Namespace]:="http://www.sat.gob.mx/TimbreFiscalDigital", IsNullable:=false)>  _
Partial Public Class TimbreFiscalDigital
    Inherits Object
    Implements System.ComponentModel.INotifyPropertyChanged
    
    Private versionField As String
    
    Private uUIDField As String
    
    Private fechaTimbradoField As Date
    
    Private selloCFDField As String
    
    Private noCertificadoSATField As String
    
    Private selloSATField As String
    
    Public Sub New()
        MyBase.New
        Me.versionField = "1.0"
    End Sub
    
    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>  _
    Public Property version() As String
        Get
            Return Me.versionField
        End Get
        Set
            Me.versionField = value
            Me.RaisePropertyChanged("version")
        End Set
    End Property
    
    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>  _
    Public Property UUID() As String
        Get
            Return Me.uUIDField
        End Get
        Set
            Me.uUIDField = value
            Me.RaisePropertyChanged("UUID")
        End Set
    End Property
    
    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>  _
    Public Property FechaTimbrado() As Date
        Get
            Return Me.fechaTimbradoField
        End Get
        Set
            Me.fechaTimbradoField = value
            Me.RaisePropertyChanged("FechaTimbrado")
        End Set
    End Property
    
    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>  _
    Public Property selloCFD() As String
        Get
            Return Me.selloCFDField
        End Get
        Set
            Me.selloCFDField = value
            Me.RaisePropertyChanged("selloCFD")
        End Set
    End Property
    
    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>  _
    Public Property noCertificadoSAT() As String
        Get
            Return Me.noCertificadoSATField
        End Get
        Set
            Me.noCertificadoSATField = value
            Me.RaisePropertyChanged("noCertificadoSAT")
        End Set
    End Property
    
    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>  _
    Public Property selloSAT() As String
        Get
            Return Me.selloSATField
        End Get
        Set
            Me.selloSATField = value
            Me.RaisePropertyChanged("selloSAT")
        End Set
    End Property
    
    Public Event PropertyChanged As System.ComponentModel.PropertyChangedEventHandler Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged
    
    Protected Sub RaisePropertyChanged(ByVal propertyName As String)
        Dim propertyChanged As System.ComponentModel.PropertyChangedEventHandler = Me.PropertyChangedEvent
        If (Not (propertyChanged) Is Nothing) Then
            propertyChanged(Me, New System.ComponentModel.PropertyChangedEventArgs(propertyName))
        End If
    End Sub
End Class