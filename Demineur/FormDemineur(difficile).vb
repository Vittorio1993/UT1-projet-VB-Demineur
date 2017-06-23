Public Class FormDemineurfacile
    Private Taille As Byte = 15
    Private NbMine As Byte = 50
    Dim temp As Integer

    Private Sub FormDemineurfacile_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        Dim cb As Button
        Dim i As Long, lig As Byte, col As Byte

        'Cette procédure permet la génération du plateau du jeu sous la forme d'un ensemble de boutons dans le panel plnJeu
        'chaque click sur un des boutons du jeu donne lieu au déclenchement de clickJeu
        'le handles de clickJeu est construit dynamiquement par l'instruction AddHandler
        'les boutons sont positionnés au fur et à mesure de leur création

        col = 1 : lig = 0
        For i = 1 To Taille * Taille
            cb = New Button
            cb.Width = 30 : cb.Height = 30 : cb.Text = ""
            cb.Tag = i  'permet de savoir le numéro du bouton qui sera cliqué
            cb.BackColor = Color.SkyBlue
            lig = lig + 1
            cb.Top = 4 + (lig - 1) * cb.Height
            cb.Left = 4 + (col - 1) * cb.Width
            Panel.Controls.Add(cb)
            AddHandler cb.MouseDown, AddressOf clickJeu
            If i Mod Taille = 0 Then
                lig = 0 : col = col + 1
            End If
        Next i

        'on initialise le Jeu
        Call Initialise(Taille, NbMine)

    End Sub

    Private Sub Affiche(ByVal i As Byte, ByVal j As Byte)
        'la procédure affiche une case
        For Each element In Panel.Controls
            If element.tag = (j - 1) * Taille + i Then
                element.text = NbMines(i, j)
            End If
        Next

    End Sub

    Private Sub ButtonEnabled(ByVal i As Byte, ByVal j As Byte)
        For Each element In Panel.Controls
            If element.tag = (j - 1) * Taille + i Then
                element.enabled = False
                element.backcolor = Color.LightGray
            End If
        Next

    End Sub

    Private Sub affichevoisin(ByVal i As Byte, ByVal j As Byte)
        'Cette procédure permet de découvrir le nombre de mine autour de la case.
        Dim a As Byte
        Dim b As Byte
        For a = i - 1 To i + 1
            For b = j - 1 To j + 1
                If a >= 1 And a <= 15 And b >= 1 And b <= 15 Then
                    If EstMarque(a, b) = False And EstDecouvert(a, b) = False Then
                        If Not (a = i And b = j) Then
                            If NbMines(a, b) = 0 Then
                                estclique(a, b)
                                affichevoisin(a, b)
                                ButtonEnabled(a, b)
                            ElseIf NbMines(a, b) <> -1 Then
                                Affiche(a, b)
                                estclique(a, b)
                                ButtonEnabled(a, b)
                            End If
                        End If
                    End If
                End If
            Next
        Next
    End Sub


    Private Sub clickJeu(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Dim cj As Byte, lig As Byte, col As Byte
        Dim nb, repondre As Integer

        'Cette procédure permet d'intercepter un click sur une des cases du jeu
        'calcul de la ligne et de la colonne correspondant à la case jouée
        cj = sender.tag
        col = Colonne(cj, Taille)
        lig = Ligne(cj, Taille)
        If lig = 0 Then
            lig = Taille : col = cj / Taille
        End If
        'activer le timer après le premier click
        Timer1.Enabled = True
        Timer1.Interval = 1000


        'on détermine si c'est un click droit ou un click gauche qui a été fait en testant e.Button
        Select Case e.Button
            Case Windows.Forms.MouseButtons.Right 'click droit

                If EstMarque(lig, col) Then

                    sender.image = Nothing
                    sender.backcolor = Color.SkyBlue
                    estcliquedroit2(lig, col)
                Else
                    estcliquedroit(lig, col)
                    sender.image = System.Drawing.Image.FromFile(Application.StartupPath & "\image\flag.png")
                End If

            Case Windows.Forms.MouseButtons.Left 'click gauche

                estclique(lig, col)

                If EstMarque(lig, col) Then
                Else
                    sender.backcolor = Color.LightGray
                    sender.enabled = False
                    estclique(lig, col)
                    If Jouer(lig, col) = -1 Then
                        Panel.Enabled = False
                        Timer1.Enabled = False 'arrêter le timer après le echec 
                        affichermine()
                        repondre = MsgBox("Sorry, you lose the game, do you want to another round ?", 4, "Information")
                        If repondre = 6 Then ' je veux rejouer alors je reinitialise le jeu
                            Panel.Enabled = True
                            Initialise(Taille, NbMine)
                            For Each element In Panel.Controls
                                element.enabled = True
                                element.text = ""
                                element.image = Nothing
                                element.backcolor = Color.SkyBlue
                            Next
                            temp = 0
                            lbltemp.Text = 0
                        Else
                            Panel.Enabled = True 'je ne veux pluss jouer alors je retourne à l'accueil
                            Initialise(Taille, NbMine)
                            For Each element In Panel.Controls
                                element.enabled = True
                                element.text = ""
                                element.image = Nothing
                                element.backcolor = Color.SkyBlue
                            Next
                            temp = 0
                            lbltemp.Text = 0
                            Me.Hide()
                            Formbienvenue.Show()
                        End If

                    ElseIf NbMines(lig, col) = 0 Then
                        affichevoisin(lig, col)
                    Else
                        Affiche(lig, col)
                    End If
                End If
        End Select
        nb = nbmarque(Taille)
        lblnbmine.Text = 50 - nb
        Reussi()

    End Sub


    Private Sub Reussi()
        'la procédure vérifie si j'ai gagné le jeu
        Dim repondre As Integer
        If estreussi(Taille) Then
            Timer1.Enabled = False 'arrêter le timer après avoir gagné
            repondre = MsgBox("You win the game and do you want to another round ? ", 4, "Information")

            ' je veux rejouer alors je reinitialise le jeu sinon je ne veux pas rejouer alors je retourne à l'accueil
            If repondre = 6 Then
                Panel.Enabled = True
                Initialise(Taille, NbMine)
                For Each element In Panel.Controls
                    element.enabled = True
                    element.text = ""
                    element.image = Nothing
                    element.backcolor = Color.SkyBlue
                Next
                temp = 0
                lbltemp.Text = 0
            Else
                Panel.Enabled = True
                Initialise(Taille, NbMine)
                For Each element In Panel.Controls
                    element.enabled = True
                    element.text = ""
                    element.image = Nothing
                    element.backcolor = Color.SkyBlue
                Next
                temp = 0
                lbltemp.Text = 0
                Me.Hide()
                Formbienvenue.Show()
            End If
        End If
    End Sub

    Private Sub affichermine()
        'Cette procédure permet d'afficher les mines.
        Dim i As Integer, j As Integer
        For i = 1 To Taille
            For j = 1 To Taille
                If Jouer(i, j) = -1 Then
                    For Each element In Panel.Controls
                        If element.tag = (j - 1) * Taille + i And EstMarque(i, j) = False Then
                            element.image = System.Drawing.Image.FromFile(Application.StartupPath & "\image\mines30.png")
                        End If
                    Next
                End If
                If Jouer(i, j) = 0 Then
                    For Each element In Panel.Controls
                        If element.tag = (j - 1) * Taille + i And EstMarque(i, j) = True Then
                            element.backcolor = Color.Red
                        End If
                    Next
                End If
            Next
        Next



    End Sub

    Private Function Ligne(ByVal cj As Byte, ByVal t As Byte) As Byte
        Return cj Mod t
    End Function

    Private Function Colonne(ByVal cj As Byte, ByVal t As Byte) As Byte
        Return Int(cj / t) + 1
    End Function

    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles Timer1.Tick
        'la procédure permet d'afficher le timer
        temp = temp + 1
        lbltemp.Text = temp

    End Sub


End Class