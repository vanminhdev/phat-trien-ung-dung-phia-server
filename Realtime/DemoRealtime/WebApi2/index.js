const express = require('express');
const http = require('http');
const socketIo = require('socket.io');

const app = express();
const server = http.createServer(app);
const io = socketIo(server);

// Xử lý kết nối từ các máy khách
io.on('connection', (socket) => {
    console.log('A client connected');

    // Xử lý khi máy khách gửi tin nhắn mới
    socket.on('send-message', (message) => {
        console.log('Received message', message)
        io.emit('message', message);
    });

    // Xử lý khi máy khách ngắt kết nối
    socket.on('disconnect', () => {
        console.log('A client disconnected');
    });
});

const PORT = process.env.PORT || 3000;
server.listen(PORT, () => {
    console.log(`Server is running on http://localhost:${PORT}`);
});
