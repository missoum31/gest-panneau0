Option Explicit On
Option Strict On


Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Collections.Generic
Imports System.Data



Public Class share
    Private Connection As SqlConnection

    Private direction As DropDownList
    Private con As SqlConnection
    Private client As DropDownList
    ' Private myconnection As SqlConnection

    Sub New(p As DropDownList, cl As DropDownList, c As SqlConnection)
        direction = p
        con = c
        client = cl
    End Sub

    Sub directionPopulate()



        Dim myread As SqlDataReader
        Dim mycomad As SqlCommand
        Dim sql As String = "select *from direction"
        mycomad = New SqlCommand(sql, con)
        myread = mycomad.ExecuteReader()
        direction.DataSource = myread
        direction.DataValueField = "id"
        direction.DataTextField = "NomDirection"
        direction.DataBind()
        direction.Items.Insert(0, New ListItem("--select Direction--", "0"))
        myread.Close()

    End Sub




    Sub ChargerListCliente()
        ' Dim myConnection As SqlConnection = CType(Session("myConnection"), SqlConnection)
        Dim myredaer As SqlDataReader
        Dim mycommand As SqlCommand
        Dim sql As String = "select *from client where idClient<>1"

        mycommand = New SqlCommand(sql, con)
        ' mycommand.CommandText = "select *from client"
        myredaer = mycommand.ExecuteReader()



        client.DataSource = myredaer
        client.DataValueField = "idClient"
        client.DataTextField = "Client"

        client.DataBind()

        client.Items.Insert(0, New ListItem("--select--", "0"))

        myredaer.Close()

    End Sub






    Protected Function validerForm(ddpaneau As DropDownList, ddchifre As DropDownList, grd As GridView, myconnection As SqlConnection) As Boolean

        'Dim curenrDrop As DropDownList = sender
        'Dim grid As GridViewRow = (curenrDrop.Parent.Parent)
        'Dim myConnection As SqlConnection = CType(Session("myConnection"), SqlConnection)
        Dim ddp As DropDownList = CType(grd.FindControl("panneau"), DropDownList)

        '  Dim disp As Label = grid.FindControl("chifre")
        Dim nomb As Integer = 0
        Dim nombre As Integer = 0
        Dim resultat As Object = New Object()
        Dim mycome As SqlCommand = New SqlCommand()
        'Dim nub As String = ddp.SelectedValue
        '   Dim riders As SqlCommand
        'mycome = New SqlCommand(somme, myConnection)
        '    mycome.CommandType = CommandType.Text
        Dim flag As Boolean = True
        Dim i As Integer

        Dim sze As String
        Dim sz As String

        '--------------------remplir label disponible-----------------------------------
        '   mycome = New SqlCommand("select SUM(nombreFace) AS dispo from MouvementStock where ID_panneau=" + nub, myConnection)

        ' If (IsNothing(mycome)) Then
        '
        mycome.CommandType = CommandType.Text
        '   resultat = mycome.ExecuteScalar()


        '      disp.Text = resultat.ToString
        '--------------------------------------------------------------------------------

        For i = 0 To (grd.Rows.Count - 1)
            sze = CType(grd.Rows(i).FindControl("famille"), DropDownList).Text
            sz = CType(grd.Rows(i).FindControl("pano"), DropDownList).Text

            mycome = New SqlCommand("select SUM(nombreFace) AS dispo from MouvementStock where ID_panneau=" + sz, myConnection)

            If (IsNothing(mycome)) Then

            Else
                mycome.CommandType = CommandType.Text
                resultat = mycome.ExecuteScalar()

            End If


            Dim ddnbr As String = CType(grd.Rows(i).FindControl("nbrface"), DropDownList).Text


            If ddp.Text = sz Then
                nombre = nombre + 1

            End If
            If (sz = "") Or (sz = "0") Then

                nomb = nomb + 1

            End If



            If (ddnbr.ToString > resultat.ToString) Then
                flag = False
            End If


        Next



        If (nomb <> 0) Or (nombre > 1) Or (flag = False) Then
            Return False
        Else
            Return True
        End If



    End Function









End Class
