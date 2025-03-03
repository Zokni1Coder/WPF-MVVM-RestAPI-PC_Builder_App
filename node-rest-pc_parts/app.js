const express = require('express');  //ez egy csomag. installaltuk a terminalban
const app = express(); //executolja az express csomagot

app.use((req, res, next) => {
    res.status(200).json({
        message: 'It works!'
    });
});

module.exports = app;