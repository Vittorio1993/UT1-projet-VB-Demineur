Module Module1

    Public Jeu(,) As SByte
    Public Decouvert(,) As Boolean
    Public Marque(,) As Boolean


    Private Sub PlacerMines(ByVal t As Byte, ByVal NbMines As Byte)
        Dim i As Byte, lig As Byte, col As Byte
        Dim mineplacee As Boolean
        Randomize()
        For i = 1 To NbMines 'je dois placer NbMines mines
            Do
                lig = CByte(Int(t * Rnd() + 1))
                col = CByte(Int(t * Rnd() + 1))
                mineplacee = Jeu(lig, col) <> -1
            Loop Until mineplacee
            Jeu(lig, col) = -1
        Next i
    End Sub

    Public Sub Initialise(ByVal taille As Byte, ByVal nbmines As Byte)
        ReDim Jeu(taille, taille)
        PlacerMines(taille, nbmines)

        'pour initialiser le jeu, on initialise les tableaux Jeu, Decouvert et Marque.
        ' Cette procédure place les mines et chiffre les cases autour des mines.

        ReDim Decouvert(taille, taille)
        ReDim Marque(taille, taille)

        For i = 1 To taille
            For j = 1 To taille
                If Jeu(i, j) = -1 Then
                    If i - 1 >= 1 And j - 1 >= 1 Then
                        If Jeu(i - 1, j - 1) <> -1 Then
                            Jeu(i - 1, j - 1) = Jeu(i - 1, j - 1) + 1
                        End If
                    End If
                    If i - 1 >= 1 Then
                        If Jeu(i - 1, j) <> -1 Then
                            Jeu(i - 1, j) = Jeu(i - 1, j) + 1
                        End If
                    End If
                    If i - 1 >= 1 And j + 1 <= taille Then
                        If Jeu(i - 1, j + 1) <> -1 Then
                            Jeu(i - 1, j + 1) = Jeu(i - 1, j + 1) + 1
                        End If
                    End If
                    If j - 1 >= 1 Then
                        If Jeu(i, j - 1) <> -1 Then
                            Jeu(i, j - 1) = Jeu(i, j - 1) + 1
                        End If
                    End If
                    If j + 1 <= taille Then
                        If Jeu(i, j + 1) <> -1 Then
                            Jeu(i, j + 1) = Jeu(i, j + 1) + 1
                        End If
                    End If
                    If j - 1 >= 1 And i + 1 <= taille Then
                        If Jeu(i + 1, j - 1) <> -1 Then
                            Jeu(i + 1, j - 1) = Jeu(i + 1, j - 1) + 1
                        End If
                    End If
                    If i + 1 <= taille Then
                        If Jeu(i + 1, j) <> -1 Then
                            Jeu(i + 1, j) = Jeu(i + 1, j) + 1
                        End If
                    End If
                    If i + 1 <= taille And j + 1 <= taille Then
                        If Jeu(i + 1, j + 1) <> -1 Then
                            Jeu(i + 1, j + 1) = Jeu(i + 1, j + 1) + 1
                        End If
                    End If
                End If
            Next
        Next

    End Sub

    Public Function Jouer(ByVal i As Byte, ByVal j As Byte) As Integer
        'vérifier les états de la case
        Dim jout As Integer
        If Jeu(i, j) = -1 Then
            jout = -1
        Else
            jout = 0
        End If
        Return jout
    End Function

    Public Function EstDecouvert(ByVal i As Byte, ByVal j As Byte) As Boolean
        'vérifier si la case est decouverte
        Dim couvert As Boolean
        couvert = Decouvert(i, j)
        Return couvert
    End Function

    Public Function EstMarque(ByVal i As Byte, ByVal j As Byte) As Boolean
        'vérifier si la case est marquée
        Dim simarque As Boolean
        simarque = Marque(i, j)
        Return simarque
    End Function

    Public Function NbMines(ByVal i As Byte, ByVal j As Byte) As Integer
        'savoir le nombre de mine dans la case adjacente
        Dim nb As Integer
        nb = Jeu(i, j)
        Return nb
    End Function

    Public Sub estclique(ByVal i As Byte, ByVal j As Byte)
        'action après click gauche
        Decouvert(i, j) = True
    End Sub

    Public Sub estcliquedroit(ByVal i As Byte, ByVal j As Byte)
        'action après click droit
        Marque(i, j) = True
    End Sub

    Public Sub estcliquedroit2(ByVal i As Byte, ByVal j As Byte)
        'action après une deuxième click droit 
        Marque(i, j) = False
    End Sub

    Public Function estreussi(ByVal taille As Byte) As Boolean
        'vérifier les conditions de réussite du jeu
        Dim i As Byte
        Dim j As Byte
        Dim reussi As Boolean = True
        For i = 1 To taille
            For j = 1 To taille
                If Marque(i, j) = True And Jeu(i, j) <> -1 Then
                    reussi = False
                End If
                If Marque(i, j) = False And Decouvert(i, j) = False Then
                    reussi = False
                End If
            Next

        Next
        Return reussi
    End Function

    Public Function nbmarque(ByVal taille As Byte) As Integer
        'Savoir le nombre de marque
        Dim i, j As Byte
        Dim nb As Integer
        For i = 1 To taille
            For j = 1 To taille
                If Marque(i, j) = True Then
                    nb = nb + 1
                End If
            Next
        Next
        Return nb
    End Function








End Module
