const express = require('express');  //ez egy csomag. installaltuk a terminalban
const app = express(); //executolja az express csomagot
const motherboardRoutes = require('./api/routes/motherboards'); //mivel itt megadtuk, ezert nem kell a motherboard.js-ben megadni, csak a "\" jelet.
const cpu_coolerRoutes = require('./api/routes/cpu_coolers');
const cpuRoutes = require('./api/routes/cpu');
const bodyParser = require('body-parser');

app.use(bodyParser.urlencoded({extended: false}));
app.use(bodyParser.json());

app.use('/motherboards', motherboardRoutes); // ennek koszonhetoen minden ami ezzel kezdodik url tovabbitva lesz a motherboard.js-be
app.use('/cpu_coolers', cpu_coolerRoutes);
app.use('/cpus', cpuRoutes);


module.exports = app;