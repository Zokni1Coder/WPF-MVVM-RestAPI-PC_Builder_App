const express = require('express');  
const app = express(); 
const motherboardRoutes = require('./api/routes/motherboards');
const cpu_coolerRoutes = require('./api/routes/cpu_coolers');
const cpuRoutes = require('./api/routes/cpus');
const gpuRoutes = require('./api/routes/gpus');
const power_suppliesRoutes = require('./api/routes/power_supplies');
const ramRoutes = require('./api/routes/rams');
const romRoutes = require('./api/routes/roms');
const bodyParser = require('body-parser');

app.use(bodyParser.urlencoded({extended: false}));
app.use(bodyParser.json());

app.use('/motherboards', motherboardRoutes); 
app.use('/cpu_coolers', cpu_coolerRoutes);
app.use('/cpus', cpuRoutes);
app.use('/gpus', gpuRoutes);
app.use('/rams', ramRoutes);
app.use('/roms', romRoutes);
app.use('/power_supplies', power_suppliesRoutes);


module.exports = app;
