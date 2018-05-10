Option Explicit On
Option Strict On

Imports System
Imports System.Text
Imports System.Data
Imports System.Data.SqlClient
Imports System.Xml
    'Imports System.Data.Xml.Xsl
Imports System.Xml.Xsl.XslCompiledTransform

Namespace GoogleAnep

        Public Class mapGoogleAnep
            Private path As String
            Private con As SqlConnection
            ' Private myconnection As SqlConnection

            Sub New(p As String, c As SqlConnection)
                path = p
                con = c

            End Sub



            Public Sub xmlPosition(xmlFichier As String)

            Dim mySet As DataSet

                Dim mycommande As SqlDataAdapter
            mySet = New DataSet()

                mycommande = New SqlDataAdapter("googleAnep", con)
                mycommande.SelectCommand.CommandType = CommandType.StoredProcedure
                'mycommande.SelectCommand.Parameters.Add(SqlDbType)
                mycommande.Fill(mySet, "panneau")
            ' mySet.WriteXml(path + xmlFichier)
            mySet.WriteXml(path + xmlFichier)

            End Sub



        End Class

    End Namespace
