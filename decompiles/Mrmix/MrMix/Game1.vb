Imports System
Imports Microsoft.Xna.Framework
Imports Microsoft.Xna.Framework.Audio
Imports Microsoft.Xna.Framework.Graphics
Imports Microsoft.Xna.Framework.Input

Namespace MrMix
	' Token: 0x02000003 RID: 3
	Public Class Game1
		Inherits Game

		' Token: 0x06000005 RID: 5 RVA: 0x000020E8 File Offset: 0x000002E8
		Public Sub New()
			Me.graphics = New GraphicsDeviceManager(Me)
			MyBase.Content.RootDirectory = "Content"
		End Sub

		' Token: 0x06000006 RID: 6 RVA: 0x00002289 File Offset: 0x00000489
		Protected Overrides Sub Initialize()
			Me.graphics.PreferredBackBufferHeight = 720
			Me.graphics.PreferredBackBufferWidth = 1280
			Me.graphics.ApplyChanges()
			Me.clock.initialize()
			MyBase.Initialize()
		End Sub

		' Token: 0x06000007 RID: 7 RVA: 0x000022C8 File Offset: 0x000004C8
		Protected Overrides Sub LoadContent()
			Me.spriteBatch = New SpriteBatch(MyBase.GraphicsDevice)
			Me.start = MyBase.Content.Load(Of Texture2D)("sprites\start")
			Me.black = MyBase.Content.Load(Of Texture2D)("sprites\black")
			Me.background = MyBase.Content.Load(Of Texture2D)("sprites\background")
			Me.Standard = MyBase.Content.Load(Of SpriteFont)("SpriteFont1")
			Me.Standardsmall = MyBase.Content.Load(Of SpriteFont)("SpriteFont2")
			Me.Debug = MyBase.Content.Load(Of SpriteFont)("Debug")
			Me.growl = MyBase.Content.Load(Of SoundEffect)("sounds\growl")
			Me.growlinstance = Me.growl.CreateInstance()
			Me.hairdryer = MyBase.Content.Load(Of SoundEffect)("sounds\hairdryer")
			Me.bell = MyBase.Content.Load(Of SoundEffect)("sounds\bell")
			Me.bellinstance = Me.bell.CreateInstance()
			Me.hairinstance = Me.hairdryer.CreateInstance()
			Me.FontPos = New Vector2(50F, 50F)
			Me.FontPossmall = New Vector2(50F, 50F)
			Me.FontPosDebug = New Vector2(50F, 50F)
		End Sub

		' Token: 0x06000008 RID: 8 RVA: 0x0000241E File Offset: 0x0000061E
		Protected Overrides Sub UnloadContent()
		End Sub

		' Token: 0x06000009 RID: 9 RVA: 0x00002420 File Offset: 0x00000620
		Protected Overrides Sub Update(gameTime As GameTime)
			GamePad.GetState(0)
			Dim KS As KeyboardState = Keyboard.GetState()
			Dim MS As MouseState = Mouse.GetState()
			Me.ms = MS
			Me.ks = KS
			Me.DYNATIMER = Me.clock.dyntimer
			Me.TIMEOUT = Me.clock.timeOut
			If KS.IsKeyDown(119) Then
				Me.debug = True
			End If
			If KS.IsKeyDown(120) Then
				Me.debug = False
			End If
			If Me.debug Then
				If KS.IsKeyDown(96) Then
					Me.state = 0
					Me.growlinstance.[Stop]()
					Me.hairinstance.[Stop]()
					Me.bellinstance.[Stop]()
				End If
				If KS.IsKeyDown(97) Then
					Me.state = 1
					Me.level = 1
					Me.hairinstance.[Stop]()
					Me.bellinstance.[Stop]()
					Me.clock.dyntimer = 60
				End If
				If KS.IsKeyDown(98) Then
					Me.state = 2
					Me.growlinstance.[Stop]()
					Me.hairinstance.[Stop]()
					Me.bellinstance.[Stop]()
				End If
				If KS.IsKeyDown(99) Then
					Me.state = 3
					Me.level = 2
					Me.growlinstance.[Stop]()
					Me.hairinstance.[Stop]()
					Me.bellinstance.[Stop]()
					Me.clock.dyntimer = 60
				End If
				If KS.IsKeyDown(100) Then
					Me.state = 4
					Me.growlinstance.[Stop]()
					Me.hairinstance.[Stop]()
					Me.bellinstance.[Stop]()
				End If
				If KS.IsKeyDown(101) Then
					Me.state = 5
					Me.level = 3
					Me.hairinstance.[Stop]()
					Me.bellinstance.[Stop]()
					Me.clock.dyntimer = 60
				End If
				If KS.IsKeyDown(102) Then
					Me.state = 6
					Me.growlinstance.[Stop]()
					Me.hairinstance.[Stop]()
					Me.bellinstance.[Stop]()
				End If
				If KS.IsKeyDown(103) Then
					Me.state = 7
					Me.level = 4
					Me.growlinstance.[Stop]()
					Me.hairinstance.[Stop]()
					Me.clock.dyntimer = 60
				End If
				If KS.IsKeyDown(104) Then
					Me.state = 8
					Me.growlinstance.[Stop]()
					Me.hairinstance.[Stop]()
					Me.bellinstance.[Stop]()
				End If
				If KS.IsKeyDown(105) Then
					Me.state = 9
					Me.level = 5
					Me.growlinstance.[Stop]()
					Me.hairinstance.[Stop]()
					Me.clock.dyntimer = 60
				End If
			End If
			Me.Mousepos.X = CSng(MS.X)
			Me.Mousepos.Y = CSng(MS.Y)
			Select Case Me.state
				Case -1
					If KS.IsKeyDown(13) Then
						Me.state = Me.level
						Me.clock.dyntimer = 60
					End If
					If KS.IsKeyDown(27) Then
						MyBase.[Exit]()
					End If
				Case 0
					If Me.Mousepos.X >= Me.startPos.X AndAlso Me.Mousepos.X <= Me.startPos.X + CSng(Me.start.Width) AndAlso Me.Mousepos.Y >= Me.startPos.Y AndAlso Me.Mousepos.Y <= Me.startPos.Y + CSng(Me.start.Height) AndAlso Me.ms.LeftButton = 1 Then
						Me.state = 1
						Me.level = 1
						Me.clock.dyntimer = 60
					End If
				Case 1
					Me.clock.start()
					Me.growlinstance.Volume = Me.volume
					If Me.DYNATIMER <> 0 Then
						If Me.abspielen Then
							Me.growlinstance.Play()
							Me.abspielen = False
						End If
						If Me.growlinstance.State = 2 AndAlso Me.wiederholen <> 8 Then
							Me.volume += 0.1F
							Me.abspielen = True
							Me.wiederholen += 1
						End If
						For i As Integer = 0 To 10 - 1
							If Me.woerterrichtig = i Then
								Me.WortUpdate(Me.wortlist(i))
							End If
							If Me.woerterrichtig = 10 Then
								Me.state = 2
							End If
						Next
					Else
						Me.state = -1
					End If
				Case 2
					If KS.IsKeyDown(13) Then
						Me.state = 3
						Me.level = 2
						Me.woerterrichtig = 0
						Me.clock.dyntimer = 60
					End If
					If KS.IsKeyDown(27) Then
						MyBase.[Exit]()
					End If
				Case 3
					Me.clock.start()
					If Me.DYNATIMER <> 0 Then
						If Me.callrandom Then
							Me.random = Me.rnd.[Next](1, 27)
							Me.callrandom = False
						End If
						For j As Integer = 0 To 30 - 1
							If Me.woerterrichtig = j Then
								Me.WortUpdate(Me.wortlist(Me.random))
							End If
							If Me.woerterrichtig = 30 Then
								Me.state = 4
							End If
						Next
					Else
						Me.state = -1
					End If
				Case 4
					If KS.IsKeyDown(13) Then
						Me.state = 5
						Me.level = 3
						Me.woerterrichtig = 0
						Me.clock.dyntimer = 60
					End If
					If KS.IsKeyDown(27) Then
						MyBase.[Exit]()
					End If
				Case 5
					Me.clock.start()
					If Me.DYNATIMER <> 0 Then
						Me.hairinstance.Play()
						If Me.callrandom Then
							Me.random = Me.rnd.[Next](1, 27)
							Me.callrandom = False
						End If
						For k As Integer = 0 To 85 - 1
							If Me.woerterrichtig = k Then
								Me.WortUpdate(Me.wortlist(Me.random))
							End If
							If Me.woerterrichtig = 85 Then
								Me.state = 6
							End If
						Next
					Else
						Me.state = -1
					End If
				Case 6
					If KS.IsKeyDown(13) Then
						Me.state = 7
						Me.level = 4
						Me.woerterrichtig = 0
						Me.clock.dyntimer = 60
					End If
					If KS.IsKeyDown(27) Then
						MyBase.[Exit]()
					End If
				Case 7
					Me.clock.start()
					If Me.DYNATIMER <> 0 Then
						Me.bellinstance.Play()
						If Me.callrandom Then
							Me.random = Me.rnd.[Next](1, 27)
							Me.callrandom = False
						End If
						For l As Integer = 0 To 292 - 1
							If Me.woerterrichtig = l Then
								Me.WortUpdate(Me.wortlist(Me.random))
							End If
							If Me.woerterrichtig = 292 Then
								Me.state = 6
							End If
						Next
					Else
						Me.state = -1
					End If
				Case 8
					If KS.IsKeyDown(13) Then
						Me.state = 9
						Me.level = 5
						Me.woerterrichtig = 0
						Me.clock.dyntimer = 60
					End If
					If KS.IsKeyDown(27) Then
						MyBase.[Exit]()
					End If
				Case 9
					Me.clock.start()
					If Me.DYNATIMER <> 0 Then
						Me.bellinstance.Play()
						If Me.callrandom Then
							Me.random = Me.rnd.[Next](1, 27)
							Me.callrandom = False
						End If
						For m As Integer = 0 To 500 - 1
							If Me.woerterrichtig = m Then
								Me.WortUpdate(Me.wortlist(Me.random))
							End If
							If Me.woerterrichtig = 500 Then
								MyBase.[Exit]()
							End If
						Next
					Else
						Me.state = -1
					End If
			End Select
			MyBase.Update(gameTime)
		End Sub

		' Token: 0x0600000A RID: 10 RVA: 0x00002C50 File Offset: 0x00000E50
		Protected Overrides Sub Draw(gameTime As GameTime)
			MyBase.GraphicsDevice.Clear(Color.CornflowerBlue)
			Me.spriteBatch.Begin()
			MyBase.IsMouseVisible = True
			Dim stringtimer As String = Convert.ToString(Me.DYNATIMER)
			Me.spriteBatch.Draw(Me.background, New Rectangle(0, 0, Me.background.Width, Me.background.Height), Color.White)
			If Me.debug Then
				Dim Tdebug As String = "Debug"
				Dim guys As String = "Hey, why are you looking at this? GO AWAY!"
				Dim twoerterrichtig As String = "Correct words:"
				Dim zwoerterrichtig As String = Convert.ToString(Me.woerterrichtig)
				Dim tlevel As String = "Level:"
				Dim zlevel As String = Convert.ToString(Me.level)
				Dim tlettercount As String = "Letter counter:"
				Dim zlettercount As String = Convert.ToString(Me.lettercount)
				Dim twordlength As String = "Word length:"
				Dim zwordlength As String = Convert.ToString(Me.WORT.Length)
				Dim timeOUT As String = Convert.ToString(Me.TIMEOUT)
				Dim credit As String = "This game was created by Jackjan  youtube.com/jackjan4"
				Dim version As String = "V 1.1"
				Me.spriteBatch.DrawString(Me.Debug, guys, New Vector2(850F, 10F), Color.Black)
				Me.spriteBatch.DrawString(Me.Debug, Tdebug, New Vector2(1200F, 20F), Color.Black)
				Me.spriteBatch.DrawString(Me.Debug, tlevel, New Vector2(1100F, 50F), Color.Black)
				Me.spriteBatch.DrawString(Me.Debug, zlevel, New Vector2(1250F, 50F), Color.Black)
				Me.spriteBatch.DrawString(Me.Debug, twoerterrichtig, New Vector2(1100F, 60F), Color.Black)
				Me.spriteBatch.DrawString(Me.Debug, zwoerterrichtig, New Vector2(1250F, 60F), Color.Black)
				Me.spriteBatch.DrawString(Me.Debug, tlettercount, New Vector2(1100F, 80F), Color.Black)
				Me.spriteBatch.DrawString(Me.Debug, zlettercount, New Vector2(1250F, 80F), Color.Black)
				Me.spriteBatch.DrawString(Me.Debug, twordlength, New Vector2(1100F, 90F), Color.Black)
				Me.spriteBatch.DrawString(Me.Debug, zwordlength, New Vector2(1250F, 90F), Color.Black)
				Me.spriteBatch.DrawString(Me.Debug, timeOUT, New Vector2(1250F, 100F), Color.Black)
				Me.spriteBatch.DrawString(Me.Debug, version, New Vector2(1200F, 110F), Color.Black)
				Me.spriteBatch.DrawString(Me.Debug, credit, New Vector2(850F, 120F), Color.Black)
			End If
			Dim great As String = "Great!"
			Dim enter As String = "Enter: Next Level"
			Dim escape As String = "ESC: Exit"
			Select Case Me.state
				Case -1
					Dim failed As String = "You failed!"
					Dim again As String = "Enter: Try Again"
					Me.spriteBatch.DrawString(Me.Standard, failed, New Vector2(60F, 60F), Color.Black)
					Me.spriteBatch.DrawString(Me.Standard, again, New Vector2(20F, 200F), Color.Black)
					Me.spriteBatch.DrawString(Me.Standard, escape, New Vector2(20F, 240F), Color.Black)
				Case 0
					Me.spriteBatch.Draw(Me.start, New Rectangle(180, 640, Me.start.Width, Me.start.Height), Color.White)
				Case 1
					Dim OutLevel As String = "Level 1"
					Dim TypeThis As String = "Type this:"
					Me.spriteBatch.DrawString(Me.Standard, Me.wortlist(Me.woerterrichtig), New Vector2(500F, 500F), Color.Black)
					Me.spriteBatch.DrawString(Me.Standard, stringtimer, New Vector2(200F, 650F), Color.Black)
					Me.spriteBatch.DrawString(Me.Standard, OutLevel, New Vector2(20F, 20F), Color.Black)
					Me.spriteBatch.DrawString(Me.Standardsmall, TypeThis, New Vector2(200F, 250F), Color.Black)
					If Me.lettercount >= 1 Then
						Me.spriteBatch.Draw(Me.black, New Vector2(500F, 495F), Color.Black)
						If Me.lettercount >= 2 Then
							Me.spriteBatch.Draw(Me.black, New Vector2(530F, 495F), Color.Black)
							If Me.lettercount >= 3 Then
								Me.spriteBatch.Draw(Me.black, New Vector2(560F, 495F), Color.Black)
								If Me.lettercount >= 4 Then
									Me.spriteBatch.Draw(Me.black, New Vector2(590F, 495F), Color.Black)
									If Me.lettercount >= 5 Then
										Me.spriteBatch.Draw(Me.black, New Vector2(620F, 495F), Color.Black)
										If Me.lettercount >= 6 Then
											Me.spriteBatch.Draw(Me.black, New Vector2(650F, 495F), Color.Black)
											If Me.lettercount >= 7 Then
												Me.spriteBatch.Draw(Me.black, New Vector2(680F, 495F), Color.Black)
												If Me.lettercount >= 8 Then
													Me.spriteBatch.Draw(Me.black, New Vector2(710F, 495F), Color.Black)
													If Me.lettercount >= 9 Then
														Me.spriteBatch.Draw(Me.black, New Vector2(720F, 495F), Color.Black)
														If Me.lettercount >= 10 Then
															Me.spriteBatch.Draw(Me.black, New Vector2(750F, 495F), Color.Black)
														End If
													End If
												End If
											End If
										End If
									End If
								End If
							End If
						End If
					End If
				Case 2
					Me.spriteBatch.DrawString(Me.Standard, great, New Vector2(60F, 60F), Color.Black)
					Me.spriteBatch.DrawString(Me.Standardsmall, enter, New Vector2(20F, 200F), Color.Black)
					Me.spriteBatch.DrawString(Me.Standard, escape, New Vector2(20F, 240F), Color.Black)
				Case 3
					Dim OutLevel2 As String = "Level 2"
					Dim TypeThis2 As String = "Type this:"
					Me.spriteBatch.DrawString(Me.Standard, stringtimer, New Vector2(200F, 650F), Color.Black)
					Me.spriteBatch.DrawString(Me.Standard, Me.wortlist(Me.random), New Vector2(500F, 500F), Color.Black)
					Me.spriteBatch.DrawString(Me.Standard, OutLevel2, New Vector2(20F, 20F), Color.Black)
					Me.spriteBatch.DrawString(Me.Standardsmall, TypeThis2, New Vector2(200F, 250F), Color.Black)
					If Me.lettercount >= 1 Then
						Me.spriteBatch.Draw(Me.black, New Vector2(500F, 495F), Color.Black)
						If Me.lettercount >= 2 Then
							Me.spriteBatch.Draw(Me.black, New Vector2(530F, 495F), Color.Black)
							If Me.lettercount >= 3 Then
								Me.spriteBatch.Draw(Me.black, New Vector2(560F, 495F), Color.Black)
								If Me.lettercount >= 4 Then
									Me.spriteBatch.Draw(Me.black, New Vector2(590F, 495F), Color.Black)
									If Me.lettercount >= 5 Then
										Me.spriteBatch.Draw(Me.black, New Vector2(620F, 495F), Color.Black)
										If Me.lettercount >= 6 Then
											Me.spriteBatch.Draw(Me.black, New Vector2(650F, 495F), Color.Black)
											If Me.lettercount >= 7 Then
												Me.spriteBatch.Draw(Me.black, New Vector2(680F, 495F), Color.Black)
												If Me.lettercount >= 8 Then
													Me.spriteBatch.Draw(Me.black, New Vector2(710F, 495F), Color.Black)
													If Me.lettercount >= 9 Then
														Me.spriteBatch.Draw(Me.black, New Vector2(720F, 495F), Color.Black)
														If Me.lettercount >= 10 Then
															Me.spriteBatch.Draw(Me.black, New Vector2(750F, 495F), Color.Black)
														End If
													End If
												End If
											End If
										End If
									End If
								End If
							End If
						End If
					End If
				Case 4
					Me.spriteBatch.DrawString(Me.Standard, great, New Vector2(60F, 60F), Color.Black)
					Me.spriteBatch.DrawString(Me.Standardsmall, enter, New Vector2(20F, 200F), Color.Black)
					Me.spriteBatch.DrawString(Me.Standard, escape, New Vector2(20F, 240F), Color.Black)
				Case 5
					Dim OutLevel3 As String = "Level 3"
					Dim TypeThis3 As String = "Type this:"
					Me.spriteBatch.DrawString(Me.Standard, stringtimer, New Vector2(200F, 650F), Color.Black)
					Me.spriteBatch.DrawString(Me.Standard, Me.wortlist(Me.random), New Vector2(500F, 500F), Color.Black)
					Me.spriteBatch.DrawString(Me.Standard, OutLevel3, New Vector2(20F, 20F), Color.Black)
					Me.spriteBatch.DrawString(Me.Standardsmall, TypeThis3, New Vector2(200F, 250F), Color.Black)
					If Me.lettercount >= 1 Then
						Me.spriteBatch.Draw(Me.black, New Vector2(500F, 495F), Color.Black)
						If Me.lettercount >= 2 Then
							Me.spriteBatch.Draw(Me.black, New Vector2(530F, 495F), Color.Black)
							If Me.lettercount >= 3 Then
								Me.spriteBatch.Draw(Me.black, New Vector2(560F, 495F), Color.Black)
								If Me.lettercount >= 4 Then
									Me.spriteBatch.Draw(Me.black, New Vector2(590F, 495F), Color.Black)
									If Me.lettercount >= 5 Then
										Me.spriteBatch.Draw(Me.black, New Vector2(620F, 495F), Color.Black)
										If Me.lettercount >= 6 Then
											Me.spriteBatch.Draw(Me.black, New Vector2(650F, 495F), Color.Black)
											If Me.lettercount >= 7 Then
												Me.spriteBatch.Draw(Me.black, New Vector2(680F, 495F), Color.Black)
												If Me.lettercount >= 8 Then
													Me.spriteBatch.Draw(Me.black, New Vector2(710F, 495F), Color.Black)
													If Me.lettercount >= 9 Then
														Me.spriteBatch.Draw(Me.black, New Vector2(720F, 495F), Color.Black)
														If Me.lettercount >= 10 Then
															Me.spriteBatch.Draw(Me.black, New Vector2(750F, 495F), Color.Black)
														End If
													End If
												End If
											End If
										End If
									End If
								End If
							End If
						End If
					End If
				Case 6
					Me.spriteBatch.DrawString(Me.Standard, great, New Vector2(60F, 60F), Color.Black)
					Me.spriteBatch.DrawString(Me.Standardsmall, enter, New Vector2(20F, 200F), Color.Black)
					Me.spriteBatch.DrawString(Me.Standard, escape, New Vector2(20F, 240F), Color.Black)
				Case 7
					Me.spriteBatch.DrawString(Me.Standard, stringtimer, New Vector2(200F, 650F), Color.Black)
					Dim OutLevel4 As String = "Level 4"
					Dim TypeThis4 As String = "Type this:"
					Me.spriteBatch.DrawString(Me.Standard, Me.wortlist(Me.random), New Vector2(500F, 500F), Color.Black)
					Me.spriteBatch.DrawString(Me.Standard, OutLevel4, New Vector2(20F, 20F), Color.Black)
					Me.spriteBatch.DrawString(Me.Standardsmall, TypeThis4, New Vector2(200F, 250F), Color.Black)
					If Me.lettercount >= 1 Then
						Me.spriteBatch.Draw(Me.black, New Vector2(500F, 495F), Color.Black)
						If Me.lettercount >= 2 Then
							Me.spriteBatch.Draw(Me.black, New Vector2(530F, 495F), Color.Black)
							If Me.lettercount >= 3 Then
								Me.spriteBatch.Draw(Me.black, New Vector2(560F, 495F), Color.Black)
								If Me.lettercount >= 4 Then
									Me.spriteBatch.Draw(Me.black, New Vector2(590F, 495F), Color.Black)
									If Me.lettercount >= 5 Then
										Me.spriteBatch.Draw(Me.black, New Vector2(620F, 495F), Color.Black)
										If Me.lettercount >= 6 Then
											Me.spriteBatch.Draw(Me.black, New Vector2(650F, 495F), Color.Black)
											If Me.lettercount >= 7 Then
												Me.spriteBatch.Draw(Me.black, New Vector2(680F, 495F), Color.Black)
												If Me.lettercount >= 8 Then
													Me.spriteBatch.Draw(Me.black, New Vector2(710F, 495F), Color.Black)
													If Me.lettercount >= 9 Then
														Me.spriteBatch.Draw(Me.black, New Vector2(720F, 495F), Color.Black)
														If Me.lettercount >= 10 Then
															Me.spriteBatch.Draw(Me.black, New Vector2(750F, 495F), Color.Black)
														End If
													End If
												End If
											End If
										End If
									End If
								End If
							End If
						End If
					End If
				Case 8
					Me.spriteBatch.DrawString(Me.Standard, great, New Vector2(60F, 60F), Color.Black)
					Me.spriteBatch.DrawString(Me.Standardsmall, enter, New Vector2(20F, 200F), Color.Black)
					Me.spriteBatch.DrawString(Me.Standard, escape, New Vector2(20F, 240F), Color.Black)
				Case 9
					Dim OutLevel5 As String = "Level 5"
					Dim TypeThis5 As String = "Type this:"
					Me.spriteBatch.DrawString(Me.Standard, stringtimer, New Vector2(200F, 650F), Color.Black)
					Me.spriteBatch.DrawString(Me.Standard, Me.wortlist(Me.random), New Vector2(500F, 500F), Color.Black)
					Me.spriteBatch.DrawString(Me.Standard, OutLevel5, New Vector2(20F, 20F), Color.Black)
					Me.spriteBatch.DrawString(Me.Standardsmall, TypeThis5, New Vector2(200F, 250F), Color.Black)
					If Me.lettercount >= 1 Then
						Me.spriteBatch.Draw(Me.black, New Vector2(500F, 495F), Color.Black)
						If Me.lettercount >= 2 Then
							Me.spriteBatch.Draw(Me.black, New Vector2(530F, 495F), Color.Black)
							If Me.lettercount >= 3 Then
								Me.spriteBatch.Draw(Me.black, New Vector2(560F, 495F), Color.Black)
								If Me.lettercount >= 4 Then
									Me.spriteBatch.Draw(Me.black, New Vector2(590F, 495F), Color.Black)
									If Me.lettercount >= 5 Then
										Me.spriteBatch.Draw(Me.black, New Vector2(620F, 495F), Color.Black)
										If Me.lettercount >= 6 Then
											Me.spriteBatch.Draw(Me.black, New Vector2(650F, 495F), Color.Black)
											If Me.lettercount >= 7 Then
												Me.spriteBatch.Draw(Me.black, New Vector2(680F, 495F), Color.Black)
												If Me.lettercount >= 8 Then
													Me.spriteBatch.Draw(Me.black, New Vector2(710F, 495F), Color.Black)
													If Me.lettercount >= 9 Then
														Me.spriteBatch.Draw(Me.black, New Vector2(720F, 495F), Color.Black)
														If Me.lettercount >= 10 Then
															Me.spriteBatch.Draw(Me.black, New Vector2(750F, 495F), Color.Black)
														End If
													End If
												End If
											End If
										End If
									End If
								End If
							End If
						End If
					End If
			End Select
			Me.spriteBatch.[End]()
			MyBase.Draw(gameTime)
		End Sub

		' Token: 0x0600000B RID: 11 RVA: 0x00003F84 File Offset: 0x00002184
		Private Sub WortUpdate(wort As String)
			Me.WORT = wort
			Dim KS As KeyboardState = Keyboard.GetState()
			Dim MS As MouseState = Mouse.GetState()
			Me.ms = MS
			Me.ks = KS
			Dim wortsplit As String() = New String(wort.Length - 1) {}
			For i As Integer = 0 To wort.Length - 1
				wortsplit(i) = Convert.ToString(wort(i))
				Me.WORTSPLIT = wortsplit
				Me.musssplit = False
			Next
			If wortsplit(Me.lettercount) = "A" AndAlso KS.IsKeyDown(65) Then
				If Me.lettercount <> wort.Length - 1 Then
					Me.lettercount += 1
				Else
					Me.woerterrichtig += 1
					Me.callrandom = True
					Me.lettercount = 0
				End If
			End If
			If wortsplit(Me.lettercount) = "B" AndAlso KS.IsKeyDown(66) Then
				If Me.lettercount <> wort.Length - 1 Then
					Me.lettercount += 1
				Else
					Me.woerterrichtig += 1
					Me.callrandom = True
					Me.lettercount = 0
				End If
			End If
			If wortsplit(Me.lettercount) = "C" AndAlso KS.IsKeyDown(67) Then
				If Me.lettercount <> wort.Length - 1 Then
					Me.lettercount += 1
				Else
					Me.woerterrichtig += 1
					Me.callrandom = True
					Me.lettercount = 0
				End If
			End If
			If wortsplit(Me.lettercount) = "D" AndAlso KS.IsKeyDown(68) Then
				If Me.lettercount <> wort.Length - 1 Then
					Me.lettercount += 1
				Else
					Me.woerterrichtig += 1
					Me.callrandom = True
					Me.lettercount = 0
				End If
			End If
			If wortsplit(Me.lettercount) = "E" AndAlso KS.IsKeyDown(69) Then
				If Me.lettercount <> wort.Length - 1 Then
					Me.lettercount += 1
				Else
					Me.woerterrichtig += 1
					Me.callrandom = True
					Me.lettercount = 0
				End If
			End If
			If wortsplit(Me.lettercount) = "F" AndAlso KS.IsKeyDown(70) Then
				If Me.lettercount <> wort.Length - 1 Then
					Me.lettercount += 1
				Else
					Me.woerterrichtig += 1
					Me.callrandom = True
					Me.lettercount = 0
				End If
			End If
			If wortsplit(Me.lettercount) = "G" AndAlso KS.IsKeyDown(71) Then
				If Me.lettercount <> wort.Length - 1 Then
					Me.lettercount += 1
				Else
					Me.woerterrichtig += 1
					Me.callrandom = True
					Me.lettercount = 0
				End If
			End If
			If wortsplit(Me.lettercount) = "H" AndAlso KS.IsKeyDown(72) Then
				If Me.lettercount <> wort.Length - 1 Then
					Me.lettercount += 1
				Else
					Me.woerterrichtig += 1
					Me.callrandom = True
					Me.lettercount = 0
				End If
			End If
			If wortsplit(Me.lettercount) = "I" AndAlso KS.IsKeyDown(73) Then
				If Me.lettercount <> wort.Length - 1 Then
					Me.lettercount += 1
				Else
					Me.woerterrichtig += 1
					Me.callrandom = True
					Me.lettercount = 0
				End If
			End If
			If wortsplit(Me.lettercount) = "J" AndAlso KS.IsKeyDown(74) Then
				If Me.lettercount <> wort.Length - 1 Then
					Me.lettercount += 1
				Else
					Me.woerterrichtig += 1
					Me.callrandom = True
					Me.lettercount = 0
				End If
			End If
			If wortsplit(Me.lettercount) = "K" AndAlso KS.IsKeyDown(75) Then
				If Me.lettercount <> wort.Length - 1 Then
					Me.lettercount += 1
				Else
					Me.woerterrichtig += 1
					Me.callrandom = True
					Me.lettercount = 0
				End If
			End If
			If wortsplit(Me.lettercount) = "L" AndAlso KS.IsKeyDown(76) Then
				If Me.lettercount <> wort.Length - 1 Then
					Me.lettercount += 1
				Else
					Me.woerterrichtig += 1
					Me.callrandom = True
					Me.lettercount = 0
				End If
			End If
			If wortsplit(Me.lettercount) = "M" AndAlso KS.IsKeyDown(77) Then
				If Me.lettercount <> wort.Length - 1 Then
					Me.lettercount += 1
				Else
					Me.woerterrichtig += 1
					Me.callrandom = True
					Me.lettercount = 0
				End If
			End If
			If wortsplit(Me.lettercount) = "N" AndAlso KS.IsKeyDown(78) Then
				If Me.lettercount <> wort.Length - 1 Then
					Me.lettercount += 1
				Else
					Me.woerterrichtig += 1
					Me.callrandom = True
					Me.lettercount = 0
				End If
			End If
			If wortsplit(Me.lettercount) = "O" AndAlso KS.IsKeyDown(79) Then
				If Me.lettercount <> wort.Length - 1 Then
					Me.lettercount += 1
				Else
					Me.woerterrichtig += 1
					Me.callrandom = True
					Me.lettercount = 0
				End If
			End If
			If wortsplit(Me.lettercount) = "P" AndAlso KS.IsKeyDown(80) Then
				If Me.lettercount <> wort.Length - 1 Then
					Me.lettercount += 1
				Else
					Me.woerterrichtig += 1
					Me.callrandom = True
					Me.lettercount = 0
				End If
			End If
			If wortsplit(Me.lettercount) = "Q" AndAlso KS.IsKeyDown(81) Then
				If Me.lettercount <> wort.Length - 1 Then
					Me.lettercount += 1
				Else
					Me.woerterrichtig += 1
					Me.callrandom = True
					Me.lettercount = 0
				End If
			End If
			If wortsplit(Me.lettercount) = "R" AndAlso KS.IsKeyDown(82) Then
				If Me.lettercount <> wort.Length - 1 Then
					Me.lettercount += 1
				Else
					Me.woerterrichtig += 1
					Me.callrandom = True
					Me.lettercount = 0
				End If
			End If
			If wortsplit(Me.lettercount) = "S" AndAlso KS.IsKeyDown(83) Then
				If Me.lettercount <> wort.Length - 1 Then
					Me.lettercount += 1
				Else
					Me.woerterrichtig += 1
					Me.callrandom = True
					Me.lettercount = 0
				End If
			End If
			If wortsplit(Me.lettercount) = "T" AndAlso KS.IsKeyDown(84) Then
				If Me.lettercount <> wort.Length - 1 Then
					Me.lettercount += 1
				Else
					Me.woerterrichtig += 1
					Me.callrandom = True
					Me.lettercount = 0
				End If
			End If
			If wortsplit(Me.lettercount) = "U" AndAlso KS.IsKeyDown(85) Then
				If Me.lettercount <> wort.Length - 1 Then
					Me.lettercount += 1
				Else
					Me.woerterrichtig += 1
					Me.callrandom = True
					Me.lettercount = 0
				End If
			End If
			If wortsplit(Me.lettercount) = "V" AndAlso KS.IsKeyDown(86) Then
				If Me.lettercount <> wort.Length - 1 Then
					Me.lettercount += 1
				Else
					Me.woerterrichtig += 1
					Me.callrandom = True
					Me.lettercount = 0
				End If
			End If
			If wortsplit(Me.lettercount) = "W" AndAlso KS.IsKeyDown(87) Then
				If Me.lettercount <> wort.Length - 1 Then
					Me.lettercount += 1
				Else
					Me.woerterrichtig += 1
					Me.callrandom = True
					Me.lettercount = 0
				End If
			End If
			If wortsplit(Me.lettercount) = "X" AndAlso KS.IsKeyDown(88) Then
				If Me.lettercount <> wort.Length - 1 Then
					Me.lettercount += 1
				Else
					Me.woerterrichtig += 1
					Me.callrandom = True
					Me.lettercount = 0
				End If
			End If
			If wortsplit(Me.lettercount) = "Y" AndAlso KS.IsKeyDown(89) Then
				If Me.lettercount <> wort.Length - 1 Then
					Me.lettercount += 1
				Else
					Me.woerterrichtig += 1
					Me.callrandom = True
					Me.lettercount = 0
				End If
			End If
			If wortsplit(Me.lettercount) = "Z" AndAlso KS.IsKeyDown(90) Then
				If Me.lettercount <> wort.Length - 1 Then
					Me.lettercount += 1
					Return
				End If
				Me.woerterrichtig += 1
				Me.callrandom = True
				Me.lettercount = 0
			End If
		End Sub

		' Token: 0x04000004 RID: 4
		Private graphics As GraphicsDeviceManager

		' Token: 0x04000005 RID: 5
		Private spriteBatch As SpriteBatch

		' Token: 0x04000006 RID: 6
		Private rnd As Random = New Random()

		' Token: 0x04000007 RID: 7
		Private random As Integer

		' Token: 0x04000008 RID: 8
		Private DYNATIMER As Integer

		' Token: 0x04000009 RID: 9
		Private TIMEOUT As Integer

		' Token: 0x0400000A RID: 10
		Private clock As secondtimer = New secondtimer()

		' Token: 0x0400000B RID: 11
		Private callrandom As Boolean = True

		' Token: 0x0400000C RID: 12
		Private debug As Boolean

		' Token: 0x0400000D RID: 13
		Private WORT As String

		' Token: 0x0400000E RID: 14
		Private level As Integer

		' Token: 0x0400000F RID: 15
		Private strPath As String = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)

		' Token: 0x04000010 RID: 16
		Private abspielen As Boolean = True

		' Token: 0x04000011 RID: 17
		Private wiederholen As Integer

		' Token: 0x04000012 RID: 18
		Private volume As Single = 0.1F

		' Token: 0x04000013 RID: 19
		Private start As Texture2D

		' Token: 0x04000014 RID: 20
		Private black As Texture2D

		' Token: 0x04000015 RID: 21
		Private background As Texture2D

		' Token: 0x04000016 RID: 22
		Private growl As SoundEffect

		' Token: 0x04000017 RID: 23
		Private hairdryer As SoundEffect

		' Token: 0x04000018 RID: 24
		Private bell As SoundEffect

		' Token: 0x04000019 RID: 25
		Private bellinstance As SoundEffectInstance

		' Token: 0x0400001A RID: 26
		Private growlinstance As SoundEffectInstance

		' Token: 0x0400001B RID: 27
		Private hairinstance As SoundEffectInstance

		' Token: 0x0400001C RID: 28
		Private Standard As SpriteFont

		' Token: 0x0400001D RID: 29
		Private Standardsmall As SpriteFont

		' Token: 0x0400001E RID: 30
		Private Debug As SpriteFont

		' Token: 0x0400001F RID: 31
		Private FontPos As Vector2

		' Token: 0x04000020 RID: 32
		Private FontPossmall As Vector2

		' Token: 0x04000021 RID: 33
		Private FontPosDebug As Vector2

		' Token: 0x04000022 RID: 34
		Private wortlist As String() = New String() { "CUCUMBER", "SALAD", "POTATO", "ONION", "APPLE", "BANANA", "TOMATO", "CARROT", "GRAPEFRUIT", "STRAWBERRY", "ORANGE", "MUSHROOM", "PEPPER", "BROCCOLI", "LETTUCE", "RADISH", "BLACKBERRY", "COCONUT", "KIWI", "LEMON", "CHERRY", "MELON", "NUT", "PEACH", "PEAR", "PINEAPPLE", "RASPBERRY" }

		' Token: 0x04000023 RID: 35
		Private musssplit As Boolean = True

		' Token: 0x04000024 RID: 36
		Private WORTSPLIT As String()

		' Token: 0x04000025 RID: 37
		Private lettercount As Integer

		' Token: 0x04000026 RID: 38
		Private woerterrichtig As Integer

		' Token: 0x04000027 RID: 39
		Private ms As MouseState = Mouse.GetState()

		' Token: 0x04000028 RID: 40
		Private ks As KeyboardState = Keyboard.GetState()

		' Token: 0x04000029 RID: 41
		Private Mousepos As Vector2 = Nothing

		' Token: 0x0400002A RID: 42
		Private state As Integer

		' Token: 0x0400002B RID: 43
		Private startPos As Vector2 = New Vector2(180F, 640F)
	End Class
End Namespace
