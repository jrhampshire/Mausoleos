﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.17929
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict Off
Option Explicit On

Imports System.Xml.Serialization

'
'This source code was auto-generated by xsd, Version=4.0.30319.17929.
'

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929"), _
 System.SerializableAttribute(), _
 System.Diagnostics.DebuggerStepThroughAttribute(), _
 System.ComponentModel.DesignerCategoryAttribute("code"), _
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.sat.gob.mx/nomina"), _
 System.Xml.Serialization.XmlRootAttribute([Namespace]:="http://www.sat.gob.mx/nomina", IsNullable:=False)> _
Partial Public Class Nomina
    Inherits Object
    Implements System.ComponentModel.INotifyPropertyChanged

    <System.Xml.Serialization.XmlAttribute("schemaLocation", [Namespace]:="http://www.w3.org/2001/XMLSchema-instance")> _
    Public SchemaLocation As String = "http://www.sat.gob.mx/nomina  http://www.sat.gob.mx/sitio_internet/cfd/nomina/nomina11.xsd"

    Private percepcionesField As NominaPercepciones

    Private deduccionesField As NominaDeducciones

    Private incapacidadesField() As NominaIncapacidad

    Private horasExtrasField() As NominaHorasExtra

    Private versionField As String

    Private registroPatronalField As String

    Private numEmpleadoField As String

    Private cURPField As String

    Private tipoRegimenField As Integer

    Private numSeguridadSocialField As String

    Private fechaPagoField As Date

    Private fechaInicialPagoField As Date

    Private fechaFinalPagoField As Date

    Private numDiasPagadosField As Decimal

    Private departamentoField As String

    Private cLABEField As String

    Private bancoField As String = "" ' Integer

    Private bancoFieldSpecified As Boolean

    Private fechaInicioRelLaboralField As Date

    Private fechaInicioRelLaboralFieldSpecified As Boolean

    Private antiguedadField As Integer

    Private antiguedadFieldSpecified As Boolean

    Private puestoField As String

    Private tipoContratoField As String

    Private tipoJornadaField As String

    Private periodicidadPagoField As String

    Private salarioBaseCotAporField As Decimal

    Private salarioBaseCotAporFieldSpecified As Boolean

    Private riesgoPuestoField As Integer

    Private riesgoPuestoFieldSpecified As Boolean

    Private salarioDiarioIntegradoField As Decimal

    Private salarioDiarioIntegradoFieldSpecified As Boolean

    Public Sub New()
        MyBase.New()
        Me.versionField = "1.1"
    End Sub

    '''<remarks/>
    Public Property Percepciones() As NominaPercepciones
        Get
            Return Me.percepcionesField
        End Get
        Set(value As NominaPercepciones)
            Me.percepcionesField = Value
            Me.RaisePropertyChanged("Percepciones")
        End Set
    End Property

    '''<remarks/>
    Public Property Deducciones() As NominaDeducciones
        Get
            Return Me.deduccionesField
        End Get
        Set(value As NominaDeducciones)
            Me.deduccionesField = Value
            Me.RaisePropertyChanged("Deducciones")
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlArrayItemAttribute("Incapacidad", IsNullable:=False)> _
    Public Property Incapacidades() As NominaIncapacidad()
        Get
            Return Me.incapacidadesField
        End Get
        Set(value As NominaIncapacidad())
            Me.incapacidadesField = Value
            Me.RaisePropertyChanged("Incapacidades")
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlArrayItemAttribute("HorasExtra", IsNullable:=False)> _
    Public Property HorasExtras() As NominaHorasExtra()
        Get
            Return Me.horasExtrasField
        End Get
        Set(value As NominaHorasExtra())
            Me.horasExtrasField = Value
            Me.RaisePropertyChanged("HorasExtras")
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()> _
    Public Property Version() As String
        Get
            Return Me.versionField
        End Get
        Set(value As String)
            Me.versionField = Value
            Me.RaisePropertyChanged("Version")
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()> _
    Public Property RegistroPatronal() As String
        Get
            Return Me.registroPatronalField
        End Get
        Set(value As String)
            Me.registroPatronalField = Value
            Me.RaisePropertyChanged("RegistroPatronal")
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()> _
    Public Property NumEmpleado() As String
        Get
            Return Me.numEmpleadoField
        End Get
        Set(value As String)
            Me.numEmpleadoField = Value
            Me.RaisePropertyChanged("NumEmpleado")
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()> _
    Public Property CURP() As String
        Get
            Return Me.cURPField
        End Get
        Set(value As String)
            Me.cURPField = Value
            Me.RaisePropertyChanged("CURP")
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()> _
    Public Property TipoRegimen() As Integer
        Get
            Return Me.tipoRegimenField
        End Get
        Set(value As Integer)
            Me.tipoRegimenField = Value
            Me.RaisePropertyChanged("TipoRegimen")
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()> _
    Public Property NumSeguridadSocial() As String
        Get
            Return Me.numSeguridadSocialField
        End Get
        Set(value As String)
            Me.numSeguridadSocialField = Value
            Me.RaisePropertyChanged("NumSeguridadSocial")
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute(DataType:="date")> _
    Public Property FechaPago() As Date
        Get
            Return Me.fechaPagoField
        End Get
        Set(value As Date)
            Me.fechaPagoField = Value
            Me.RaisePropertyChanged("FechaPago")
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute(DataType:="date")> _
    Public Property FechaInicialPago() As Date
        Get
            Return Me.fechaInicialPagoField
        End Get
        Set(value As Date)
            Me.fechaInicialPagoField = Value
            Me.RaisePropertyChanged("FechaInicialPago")
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute(DataType:="date")> _
    Public Property FechaFinalPago() As Date
        Get
            Return Me.fechaFinalPagoField
        End Get
        Set(value As Date)
            Me.fechaFinalPagoField = Value
            Me.RaisePropertyChanged("FechaFinalPago")
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()> _
    Public Property NumDiasPagados() As Decimal
        Get
            Return Me.numDiasPagadosField
        End Get
        Set(value As Decimal)
            Me.numDiasPagadosField = Value
            Me.RaisePropertyChanged("NumDiasPagados")
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()> _
    Public Property Departamento() As String
        Get
            Return Me.departamentoField
        End Get
        Set(value As String)
            Me.departamentoField = Value
            Me.RaisePropertyChanged("Departamento")
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute(DataType:="integer")> _
    Public Property CLABE() As String
        Get
            Return Me.cLABEField
        End Get
        Set(value As String)
            Me.cLABEField = Value
            Me.RaisePropertyChanged("CLABE")
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()> _
    Public Property Banco As String ' Integer
        Get
            Banco = ""
            Return IIf(Me.bancoField Is Nothing, "", Me.bancoField.PadLeft(3, "0"))
        End Get
        Set(value As String)
            If String.IsNullOrEmpty(value) Then
                Me.bancoField = ""
            Else
                Me.bancoField = value.PadLeft(3, "0")
            End If
            Me.RaisePropertyChanged("Banco")
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlIgnoreAttribute()> _
    Public Property BancoSpecified As Boolean
        Get
            Return Me.bancoFieldSpecified
        End Get
        Set(value As Boolean)
            Me.bancoFieldSpecified = value
            Me.RaisePropertyChanged("BancoSpecified")
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute(DataType:="date")> _
    Public Property FechaInicioRelLaboral() As Date
        Get
            Return Me.fechaInicioRelLaboralField
        End Get
        Set(value As Date)
            Me.fechaInicioRelLaboralField = Value
            Me.RaisePropertyChanged("FechaInicioRelLaboral")
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlIgnoreAttribute()> _
    Public Property FechaInicioRelLaboralSpecified() As Boolean
        Get
            Return Me.fechaInicioRelLaboralFieldSpecified
        End Get
        Set(value As Boolean)
            Me.fechaInicioRelLaboralFieldSpecified = Value
            Me.RaisePropertyChanged("FechaInicioRelLaboralSpecified")
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()> _
    Public Property Antiguedad() As Integer
        Get
            Return Me.antiguedadField
        End Get
        Set(value As Integer)
            Me.antiguedadField = Value
            Me.RaisePropertyChanged("Antiguedad")
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlIgnoreAttribute()> _
    Public Property AntiguedadSpecified() As Boolean
        Get
            Return Me.antiguedadFieldSpecified
        End Get
        Set(value As Boolean)
            Me.antiguedadFieldSpecified = Value
            Me.RaisePropertyChanged("AntiguedadSpecified")
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()> _
    Public Property Puesto() As String
        Get
            Return Me.puestoField
        End Get
        Set(value As String)
            Me.puestoField = Value
            Me.RaisePropertyChanged("Puesto")
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()> _
    Public Property TipoContrato() As String
        Get
            Return Me.tipoContratoField
        End Get
        Set(value As String)
            Me.tipoContratoField = Value
            Me.RaisePropertyChanged("TipoContrato")
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()> _
    Public Property TipoJornada() As String
        Get
            Return Me.tipoJornadaField
        End Get
        Set(value As String)
            Me.tipoJornadaField = Value
            Me.RaisePropertyChanged("TipoJornada")
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()> _
    Public Property PeriodicidadPago() As String
        Get
            Return Me.periodicidadPagoField
        End Get
        Set(value As String)
            Me.periodicidadPagoField = Value
            Me.RaisePropertyChanged("PeriodicidadPago")
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()> _
    Public Property SalarioBaseCotApor() As Decimal
        Get
            Return Me.salarioBaseCotAporField
        End Get
        Set(value As Decimal)
            Me.salarioBaseCotAporField = Value
            Me.RaisePropertyChanged("SalarioBaseCotApor")
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlIgnoreAttribute()> _
    Public Property SalarioBaseCotAporSpecified() As Boolean
        Get
            Return Me.salarioBaseCotAporFieldSpecified
        End Get
        Set(value As Boolean)
            Me.salarioBaseCotAporFieldSpecified = Value
            Me.RaisePropertyChanged("SalarioBaseCotAporSpecified")
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()> _
    Public Property RiesgoPuesto() As Integer
        Get
            Return Me.riesgoPuestoField
        End Get
        Set(value As Integer)
            Me.riesgoPuestoField = Value
            Me.RaisePropertyChanged("RiesgoPuesto")
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlIgnoreAttribute()> _
    Public Property RiesgoPuestoSpecified() As Boolean
        Get
            Return Me.riesgoPuestoFieldSpecified
        End Get
        Set(value As Boolean)
            Me.riesgoPuestoFieldSpecified = Value
            Me.RaisePropertyChanged("RiesgoPuestoSpecified")
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()> _
    Public Property SalarioDiarioIntegrado() As Decimal
        Get
            Return Me.salarioDiarioIntegradoField
        End Get
        Set(value As Decimal)
            Me.salarioDiarioIntegradoField = Value
            Me.RaisePropertyChanged("SalarioDiarioIntegrado")
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlIgnoreAttribute()> _
    Public Property SalarioDiarioIntegradoSpecified() As Boolean
        Get
            Return Me.salarioDiarioIntegradoFieldSpecified
        End Get
        Set(value As Boolean)
            Me.salarioDiarioIntegradoFieldSpecified = Value
            Me.RaisePropertyChanged("SalarioDiarioIntegradoSpecified")
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

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929"),  _
 System.SerializableAttribute(),  _
 System.Diagnostics.DebuggerStepThroughAttribute(),  _
 System.ComponentModel.DesignerCategoryAttribute("code"),  _
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=true, [Namespace]:="http://www.sat.gob.mx/nomina")>  _
Partial Public Class NominaPercepciones
    Inherits Object
    Implements System.ComponentModel.INotifyPropertyChanged
    
    Private percepcionField() As NominaPercepcionesPercepcion
    
    Private totalGravadoField As Decimal
    
    Private totalExentoField As Decimal
    
    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute("Percepcion")>  _
    Public Property Percepcion() As NominaPercepcionesPercepcion()
        Get
            Return Me.percepcionField
        End Get
        Set
            Me.percepcionField = value
            Me.RaisePropertyChanged("Percepcion")
        End Set
    End Property
    
    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>  _
    Public Property TotalGravado() As Decimal
        Get
            Return Me.totalGravadoField
        End Get
        Set
            Me.totalGravadoField = value
            Me.RaisePropertyChanged("TotalGravado")
        End Set
    End Property
    
    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>  _
    Public Property TotalExento() As Decimal
        Get
            Return Me.totalExentoField
        End Get
        Set
            Me.totalExentoField = value
            Me.RaisePropertyChanged("TotalExento")
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

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929"),  _
 System.SerializableAttribute(),  _
 System.Diagnostics.DebuggerStepThroughAttribute(),  _
 System.ComponentModel.DesignerCategoryAttribute("code"),  _
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=true, [Namespace]:="http://www.sat.gob.mx/nomina")>  _
Partial Public Class NominaPercepcionesPercepcion
    Inherits Object
    Implements System.ComponentModel.INotifyPropertyChanged
    
    Private tipoPercepcionField As String ' Integer
    
    Private claveField As String
    
    Private conceptoField As String
    
    Private importeGravadoField As Decimal
    
    Private importeExentoField As Decimal
    
    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()> _
    Public Property TipoPercepcion() As String ' Integer
        Get
            Return Me.tipoPercepcionField.PadLeft(3, "0")
        End Get
        Set(value As String)
            Me.tipoPercepcionField = value.PadLeft(3, "0")
            Me.RaisePropertyChanged("TipoPercepcion")
        End Set
    End Property
    
    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>  _
    Public Property Clave() As String
        Get
            Return Me.claveField
        End Get
        Set
            Me.claveField = value
            Me.RaisePropertyChanged("Clave")
        End Set
    End Property
    
    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>  _
    Public Property Concepto() As String
        Get
            Return Me.conceptoField
        End Get
        Set
            Me.conceptoField = value
            Me.RaisePropertyChanged("Concepto")
        End Set
    End Property
    
    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>  _
    Public Property ImporteGravado() As Decimal
        Get
            Return Me.importeGravadoField
        End Get
        Set
            Me.importeGravadoField = value
            Me.RaisePropertyChanged("ImporteGravado")
        End Set
    End Property
    
    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>  _
    Public Property ImporteExento() As Decimal
        Get
            Return Me.importeExentoField
        End Get
        Set
            Me.importeExentoField = value
            Me.RaisePropertyChanged("ImporteExento")
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

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929"),  _
 System.SerializableAttribute(),  _
 System.Diagnostics.DebuggerStepThroughAttribute(),  _
 System.ComponentModel.DesignerCategoryAttribute("code"),  _
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=true, [Namespace]:="http://www.sat.gob.mx/nomina")>  _
Partial Public Class NominaDeducciones
    Inherits Object
    Implements System.ComponentModel.INotifyPropertyChanged
    
    Private deduccionField() As NominaDeduccionesDeduccion
    
    Private totalGravadoField As Decimal
    
    Private totalExentoField As Decimal
    
    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute("Deduccion")>  _
    Public Property Deduccion() As NominaDeduccionesDeduccion()
        Get
            Return Me.deduccionField
        End Get
        Set
            Me.deduccionField = value
            Me.RaisePropertyChanged("Deduccion")
        End Set
    End Property
    
    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>  _
    Public Property TotalGravado() As Decimal
        Get
            Return Me.totalGravadoField
        End Get
        Set
            Me.totalGravadoField = value
            Me.RaisePropertyChanged("TotalGravado")
        End Set
    End Property
    
    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>  _
    Public Property TotalExento() As Decimal
        Get
            Return Me.totalExentoField
        End Get
        Set
            Me.totalExentoField = value
            Me.RaisePropertyChanged("TotalExento")
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

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929"),  _
 System.SerializableAttribute(),  _
 System.Diagnostics.DebuggerStepThroughAttribute(),  _
 System.ComponentModel.DesignerCategoryAttribute("code"),  _
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=true, [Namespace]:="http://www.sat.gob.mx/nomina")>  _
Partial Public Class NominaDeduccionesDeduccion
    Inherits Object
    Implements System.ComponentModel.INotifyPropertyChanged
    
    Private tipoDeduccionField As String ' Integer
    
    Private claveField As String
    
    Private conceptoField As String
    
    Private importeGravadoField As Decimal
    
    Private importeExentoField As Decimal
    
    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()> _
    Public Property TipoDeduccion() As String ' Integer
        Get
            Return Me.tipoDeduccionField.PadLeft(3, "0")
        End Get
        Set(value As String)
            Me.tipoDeduccionField = value.PadLeft(3, "0")
            Me.RaisePropertyChanged("TipoDeduccion")
        End Set
    End Property
    
    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>  _
    Public Property Clave() As String
        Get
            Return Me.claveField
        End Get
        Set
            Me.claveField = value
            Me.RaisePropertyChanged("Clave")
        End Set
    End Property
    
    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>  _
    Public Property Concepto() As String
        Get
            Return Me.conceptoField.PadLeft(3, "0")
        End Get
        Set
            Me.conceptoField = Value.PadLeft(3, "0")
            Me.RaisePropertyChanged("Concepto")
        End Set
    End Property
    
    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>  _
    Public Property ImporteGravado() As Decimal
        Get
            Return Me.importeGravadoField
        End Get
        Set
            Me.importeGravadoField = value
            Me.RaisePropertyChanged("ImporteGravado")
        End Set
    End Property
    
    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>  _
    Public Property ImporteExento() As Decimal
        Get
            Return Me.importeExentoField
        End Get
        Set
            Me.importeExentoField = value
            Me.RaisePropertyChanged("ImporteExento")
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

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929"),  _
 System.SerializableAttribute(),  _
 System.Diagnostics.DebuggerStepThroughAttribute(),  _
 System.ComponentModel.DesignerCategoryAttribute("code"),  _
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=true, [Namespace]:="http://www.sat.gob.mx/nomina")>  _
Partial Public Class NominaIncapacidad
    Inherits Object
    Implements System.ComponentModel.INotifyPropertyChanged
    
    Private diasIncapacidadField As Decimal
    
    Private tipoIncapacidadField As Integer
    
    Private descuentoField As Decimal
    
    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>  _
    Public Property DiasIncapacidad() As Decimal
        Get
            Return Me.diasIncapacidadField
        End Get
        Set
            Me.diasIncapacidadField = value
            Me.RaisePropertyChanged("DiasIncapacidad")
        End Set
    End Property
    
    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>  _
    Public Property TipoIncapacidad() As Integer
        Get
            Return Me.tipoIncapacidadField
        End Get
        Set
            Me.tipoIncapacidadField = value
            Me.RaisePropertyChanged("TipoIncapacidad")
        End Set
    End Property
    
    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>  _
    Public Property Descuento() As Decimal
        Get
            Return Me.descuentoField
        End Get
        Set
            Me.descuentoField = value
            Me.RaisePropertyChanged("Descuento")
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

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929"),  _
 System.SerializableAttribute(),  _
 System.Diagnostics.DebuggerStepThroughAttribute(),  _
 System.ComponentModel.DesignerCategoryAttribute("code"),  _
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=true, [Namespace]:="http://www.sat.gob.mx/nomina")>  _
Partial Public Class NominaHorasExtra
    Inherits Object
    Implements System.ComponentModel.INotifyPropertyChanged
    
    Private diasField As Integer
    
    Private tipoHorasField As NominaHorasExtraTipoHoras
    
    Private horasExtraField As Integer
    
    Private importePagadoField As Decimal
    
    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>  _
    Public Property Dias() As Integer
        Get
            Return Me.diasField
        End Get
        Set
            Me.diasField = value
            Me.RaisePropertyChanged("Dias")
        End Set
    End Property
    
    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>  _
    Public Property TipoHoras() As NominaHorasExtraTipoHoras
        Get
            Return Me.tipoHorasField
        End Get
        Set
            Me.tipoHorasField = value
            Me.RaisePropertyChanged("TipoHoras")
        End Set
    End Property
    
    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>  _
    Public Property HorasExtra() As Integer
        Get
            Return Me.horasExtraField
        End Get
        Set
            Me.horasExtraField = value
            Me.RaisePropertyChanged("HorasExtra")
        End Set
    End Property
    
    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>  _
    Public Property ImportePagado() As Decimal
        Get
            Return Me.importePagadoField
        End Get
        Set
            Me.importePagadoField = value
            Me.RaisePropertyChanged("ImportePagado")
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

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929"),  _
 System.SerializableAttribute(),  _
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=true, [Namespace]:="http://www.sat.gob.mx/nomina")>  _
Public Enum NominaHorasExtraTipoHoras
    
    '''<remarks/>
    Dobles
    
    '''<remarks/>
    Triples
End Enum
