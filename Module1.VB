
Imports System.Runtime.CompilerServices
Imports Microsoft.VisualBasic.ApplicationServices
Imports Newtonsoft.Json

Module Module1

    'READ: 'More information on file reading and writing in the coursebook: pg 68: FileRead

    'https://drive.google.com/file/d/1qwb9Sq3bf9sWPdAUeiFX_xM1Knb4Ikpp/view

    Dim ProjectName As String
    Dim StopStatement As String
    Dim FullDirectory As String

    Sub Main()

        Dim input As String = 0

        While input <> "exit"
            Console.WriteLine("
===========================
Welcome to MelodyOrganizer
===========================


Please Name your Playlist")
            ProjectName = Console.ReadLine

            Console.WriteLine("Create 5 miniPlaylists? Yes | No")
            input = Console.ReadLine.ToString

            If input = "Yes" Then
                MakeMiniProjectFolders()
            Else MakeProjectFolders()
            End If
            'This if.. then statement allows the the serialize rate songs data to be stored in a 
            'Json file and posts it on the 
            If input = "Yes" Then
                serializeRateSong()
            Else serializeRateSong()
            End If

        End While


    End Sub
    'Added this sub to create 5 optional miniplaylists for the user
    Private Sub MakeMiniProjectFolders()
        Dim newfolderPath As String = My.Computer.FileSystem.SpecialDirectories.Desktop

        If ProjectName = "" Then

            ProjectName = " Not Set\"

        End If

        CreateProjectFolder(newfolderPath, ProjectName)

        newfolderPath += "\" + ProjectName

        FullDirectory = newfolderPath

        CreateProjectFolder(newfolderPath, "\MainPlaylist")

        CreateProjectFolder(newfolderPath, "\MainPlaylist")
        CreateProjectFolder($"{newfolderPath}\MainPlaylist", "MiniPlaylist#1")
        CreateProjectFolder($"{newfolderPath}\MainPlaylist", "MiniPlaylist#2")
        CreateProjectFolder($"{newfolderPath}\MainPlaylist", "MiniPlaylist#3")
        CreateProjectFolder($"{newfolderPath}\MainPlaylist", "MiniPlaylist#4")
        CreateProjectFolder($"{newfolderPath}\MainPlaylist", "MiniPlaylist#5")

        WriteFile("ReadMe.txt", newfolderPath)
        WriteFile("ReadMe.txt", $"{newfolderPath}\MainPlaylist")

        Console.WriteLine("Project created in: " + FullDirectory)
    End Sub

    'This sub creates one main folder
    Private Sub MakeProjectFolders()

        Dim newFolderPath As String = My.Computer.FileSystem.SpecialDirectories.Desktop

        If ProjectName = "" Then

            ProjectName = " Not Set\"

        End If

        CreateProjectFolder(newFolderPath, ProjectName)

        newFolderPath += "\" + ProjectName

        FullDirectory = newFolderPath

        CreateProjectFolder(newFolderPath, "\MainPlaylist")

        WriteFile("ReadMe.txt", newFolderPath)
        WriteFile("ReadMe.txt", $"{newFolderPath}\MainPlaylist")



        Console.WriteLine("Project created in: " + FullDirectory)

    End Sub
    'Json procedure added. the data in this procedure stores the users song ratings.
    Sub serializeRateSong()

        Dim mySong As New RateSong()
        mySong.SongName = "Song Name (1)"
        mySong.SongRating = "-/10"

        Dim Json As String = JsonConvert.SerializeObject(mySong)

        Dim location As String = My.Computer.FileSystem.SpecialDirectories.Desktop

        Dim file As IO.StreamWriter
        file = My.Computer.FileSystem.OpenTextFileWriter(location + "\jsonData.Json", True)
        file.WriteLine(Json)
        file.Close()
    End Sub
    Private Sub WriteFile(fileName As String, location As String)

        'Ref:https://docs.microsoft.com/en-us/dotnet/visual-basic/developing-apps/programming/drives-directories-files/how-to-write-text-to-files-with-a-streamwriter

        If fileName <> "" Then

            Dim file As System.IO.StreamWriter

            file = My.Computer.FileSystem.OpenTextFileWriter(location + "\" + fileName + ".txt", True)
            file.WriteLine("# Week 6 Folder Maker App

## Purpose

Explain what your app creates and why it is useful.

This app creates music playlists to organize the users music into different genres, different, vibes, etc.

## How To Run

Explain how to open and run the VB.NET project.

to start the project the user will have to first have to name a playlist in order to create it, afterwards 
they can either create one main playlist or create 5 optional MiniPlaylists to organize the music even further

## Folder Structure Created

List the folders and files your app generates

The app will generate 2 different types of folders.

1. MainPlaylist folders: these folders organize and store the music the user wants to save.

2. optional MiniPlaylist folders: these mini folders will be inside the main folders and are created to act as an option to 
organize the users main folder by further catagorizing the music.

(week 8) the application will now create a Json file. this file will contain music names and ratings for the user to add or 
delete reviews to the songs they listen to. optionally the user can also use this to rank their favortie songs

## Story to App Connection
Explain how your story or backstory led to this utility.

My backstory led to this utility because the lack of free music playing apps inspired me to create my own music playing app

## Team Members
List all team members, or write (Individual project).
(individual project)

## Screenshots
List or include screenshots showing the app, generated folders, README file, Git repo, and Discord post.")
            file.Close()
        End If

    End Sub

    Sub CreateProjectFolder(newFolderPath As String, ProjectName As String)
        My.Computer.FileSystem.CreateDirectory(newFolderPath + "\" + ProjectName)
    End Sub
End Module
