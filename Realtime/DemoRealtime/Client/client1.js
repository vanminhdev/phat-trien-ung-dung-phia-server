import signalR from '@microsoft/signalr'
import config from './config.js'

const connection = new signalR.HubConnectionBuilder()
    .withUrl(`${config.baseUrl}/chat`)
    .withAutomaticReconnect()
    .build();

connection.on("ReceiveMessage", (user, message) => {
    console.log({user, message});
});

connection.start()
    .catch(error => {
        console.error('Error connecting to SignalR hub:', error);
    });

setInterval(() => {
    connection.invoke("SendMessage", "Client1", "Hello")
        .catch(error => {
            console.error('Error invoking SendMessage:', error);
        });
}, 3000);

export default connection;