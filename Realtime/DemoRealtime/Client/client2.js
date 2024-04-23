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

export default connection;