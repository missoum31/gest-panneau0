﻿Option Explicit On
Option Strict On

Imports System
Imports System.Text
Imports System.Data
Imports System.Data.SqlClient
Imports System.Xml
'Imports System.Data.Xml.Xsl
Imports System.Xml.Xsl.XslCompiledTransform


Namespace missoum

    Public Class position
        Private user As String

        Private Connection As SqlConnection
        Private NoCommande As String
        Private Path As String


        Public Sub New(no As String, c As SqlConnection, p As String)
            NoCommande = no
            Connection = c
            Path = p
            user = userName
        End Sub

        Public Sub GenererXmlFichier(xmlFile As String)
            ' Sera implémentée plus tard
            Dim myDataSet As DataSet
            Dim CommandAdapter, LinesAdapter As SqlDataAdapter
            myDataSet = New DataSet()

            CommandAdapter = New SqlDataAdapter("position", Connection)
            CommandAdapter.SelectCommand.CommandType = CommandType.StoredProcedure
            CommandAdapter.SelectCommand.Parameters.Add("@PanneauID", SqlDbType.Int)
            CommandAdapter.SelectCommand.Parameters("@PanneauID").Value = NoCommande
            CommandAdapter.Fill(myDataSet, "panneau")


            '   myDataSet.Relations.Add("Commande_LigneCommande", _
            '  myDataSet.Tables("Commande").Columns("ID_Commande"), _
            '  myDataSet.Tables("LigneCommande").Columns("ID_Commande"))
            ' myDataSet.Relations("Commande_LigneCommande").Nested = True
            myDataSet.WriteXml(Path + xmlFile)
        End Sub



        Public Sub GenererTelecopi(xmlFile As String, xslFile As String, outputFile As String)


            'Dim myTransform As XslTransform

            Dim myTransform As Xsl.XslCompiledTransform

            'Dim myTransform As XmlValidatingReader

            Dim myDocument As XmlDocument
            Dim myWriter As XmlTextWriter

            myDocument = New XmlDocument()
            myDocument.Load(Path + xmlFile)

            'myTransform = new XslTransform()

            myTransform = New Xsl.XslCompiledTransform()
            myTransform.Load(Path + xslFile)


            myWriter = New XmlTextWriter(Path + outputFile, Encoding.UTF8)
            myTransform.Transform(myDocument, Nothing, myWriter)
            myWriter.Close()

        End Sub

    End Class
End Namespace
