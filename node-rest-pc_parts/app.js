const express = require('express');  //ez egy csomag. installaltuk a terminalban
const app = express(); //executolja az express csomagot
const motherboardRoutes = require('./api/routes/motherboards'); //mivel itt megadtuk, ezert nem kell a motherboard.js-ben megadni, csak a "\" jelet.
const bodyParser = require('body-parser');

app.use(bodyParser.urlencoded({extended: false}));
app.use(bodyParser.json());

app.use('/motherboards', motherboardRoutes); // ennek koszonhetoen minden ami ezzel kezdodik url tovabbitva lesz a motherboard.js-be

module.exports = app;