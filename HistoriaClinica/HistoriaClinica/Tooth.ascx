﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Tooth.ascx.cs" Inherits="Christoc.Modules.HistoriaClinica.Tooth" %>

<div style="float: left;
	margin-left: 5px;
	padding-bottom: 10px;
	border: solid #0094ff 1px;">

   



    <div runat="server" id="numeroElemento" style="margin-top:5px; margin-bottom:5px;font-weight:bold;text-align:center"></div>
    <div></div>
    <div class="MiniButton MiniButtonBlue">X</div>
    <div class="MiniButton MiniButtonBlue" onclick="changeCircletoBlue(this)">O</div>
    <div class="MiniButton MiniButtonRed">X</div>
    <div class="MiniButton MiniButtonRed" onclick="changeCircletoRed(this)">O</div>
    <div class="MiniButton MiniButtonGreen">B</div>
<div style="width: 40px; height: 40px;" id="diente">
    <svg id="VB" viewBox="0 0 40 40" preserveAspectRatio="xMaxyMax">
        <polygon id="T" fill="white" stroke="black" stroke-width="1px" points="0,0 40,0 32,10 8,10" onclick="changeState(this)" style="cursor:pointer"></polygon>
        <polygon id="B" fill="white" stroke="black" stroke-width="1px" points="0,40 40,40 32,30 8,30" onclick="changeState(this)" style="cursor:pointer"></polygon>
        <polygon id="L" fill="white" stroke="black" stroke-width="1px" points="0,0 8,10 8,30 0,40" onclick="changeState(this)"style="cursor:pointer"></polygon>
        <polygon id="R" fill="white" stroke="black" stroke-width="1px" points="40,0 40,40 32,30 32,10" onclick="changeState(this)"style="cursor:pointer"></polygon>
        <polygon id="C" fill="white" stroke="black" stroke-width="1px" points="8,10 32,10 32,30 8,30" onclick="changeState(this)"style="cursor:pointer"></polygon>
        <circle id="Circ" cx="20" cy="20" r="19" stroke="red" fill-opacity="0" stroke-width:"4px" visibility="hidden"></circle>
        <g id="Cros" stroke="red" stroke-width="3px" visibility="hidden">
            <line x1="0" y1="0" x2="40" y2="40"  ></line>
            <line x1="0" y1="40" x2="40" y2="0" ></line>
        </g>
        

        
        
    </svg>
</div>
</div>