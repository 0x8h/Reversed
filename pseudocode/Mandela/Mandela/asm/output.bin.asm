                .686p
                .mmx
                .model small

; Segment type: Pure code
seg000          segment byte public 'CODE' use16
                assume cs:seg000
                assume es:nothing, ss:nothing, ds:nothing, fs:nothing, gs:nothing
                xor     ax, ax
                mov     ds, ax
                mov     es, ax
                mov     ss, ax
                mov     sp, 7C00h
                mov     bp, sp
                push    0A000h
                pop     es
                assume es:nothing
                xor     di, di
                xor     ax, ax
                mov     bl, ds:7C67h
                mov     ah, 0
                mov     al, 13h
                int     10h             ; - VIDEO - SET VIDEO MODE
                                        ; AL = mode

loc_1F:                                 ; CODE XREF: seg000:005E↓j seg000:0064↓j
                mov     ah, 7
                mov     al, 0
                mov     cx, 0
                mov     dx, 184Fh
                int     10h             ; - VIDEO - SCROLL PAGE DOWN
                                        ; AL = number of lines to scroll window (0 = blank whole window)
                                        ; BH = attributes to be used on blanked lines
                                        ; CH,CL = row,column of upper left corner of window to scroll
                                        ; DH,DL = row,column of lower right corner of window
                mov     ah, 2
                mov     bh, 0
                mov     dh, 0Ah
                mov     dl, 8
                int     10h             ; - VIDEO - SET CURSOR POSITION
                                        ; DH,DL = row, column (0,0 = upper left)
                                        ; BH = page number
                mov     si, 7C69h

loc_38:                                 ; CODE XREF: seg000:0042↓j
                mov     al, [si]
                cmp     al, 0
                jz      short loc_49

loc_3E:                                 ; DATA XREF: seg000:001D↑r seg000:0029↑r ...
                call    sub_44
                inc     si
                jmp     short loc_38

; =============== S U B R O U T I N E =======================================


sub_44          proc near               ; CODE XREF: seg000:loc_3E↑p
                mov     ah, 0Eh
                int     10h             ; - VIDEO - WRITE CHARACTER AND ADVANCE CURSOR (TTY WRITE)
                                        ; AL = character, BH = display page (alpha modes)
                                        ; BL = foreground color (graphics modes)
                retn
sub_44          endp

; ---------------------------------------------------------------------------

loc_49:                                 ; CODE XREF: seg000:003C↑j
                mov     ah, 86h
                mov     cx, 0
                mov     dx, ds:7C66h
                int     15h             ; SYSTEM - WAIT (AT,XT2,XT286,CONV,PS)
                                        ; CX,DX = number of microseconds to wait
                                        ; Return: CF clear: after wait elapses, CF set: immediately due to error

loc_54:                                 ; DATA XREF: seg000:0052↑r
                cmp     bl, ds:7C68h
                jz      short loc_60
                inc     bl
                xor     bh, bl
                jmp     short loc_1F
; ---------------------------------------------------------------------------

loc_60:                                 ; CODE XREF: seg000:0058↑j
                mov     bl, ds:7C67h
                jmp     short loc_1F
; ---------------------------------------------------------------------------
                db    1
                db 10h, 1Fh
aNothingIsWorth db 'NOTHING IS WORTH THE RISK',0
                db 17Bh dup(0), 55h, 0AAh
seg000          ends


                end
; no fix. bothersome