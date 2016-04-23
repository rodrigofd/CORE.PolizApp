;#DropDB CORE.ES.FMEasyTest

#Application CORE.ES.FM.Win
#Application CORE.ES.FM.Web

*FillForm
 User Name = Admin
*Action Log On

#IfDef CORE.ES.FM.Win

*Action About...
 
*Action OK

#EndIf

#IfDef CORE.ES.FM.Web
*Action Navigation(My Details)
#EndIf
