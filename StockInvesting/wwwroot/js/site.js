﻿//// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
//// for details on configuring this project to bundle and minify static web assets.

//// Write your JavaScript code.
//const connection = new signalR.HubConnectionBuilder()
//    .withUrl("/stockHub")
//    .configureLogging(signalR.LogLevel.Information)
//    .build();

//connection.on("ReceiveMessage", (message) => {
//    $('#signalr-message-stock').prepend($('<div />').text(message));
//});

//$('#btn-submit').click(function () {
//    var message = $('#ticker').val();
//    connection.invoke("StockTickerMessage", message).catch(err => console.error('test' + err.toString()));
//});

//async function start() {
//    try {
//        await connection.start();
//        console.log('connected');
//    } catch (err) {
//        console.log(err);
//        setTimeout(() => start(), 5000);
//    }
//};

//connection.onclose(async () => {
//    await start();
//});

////start();