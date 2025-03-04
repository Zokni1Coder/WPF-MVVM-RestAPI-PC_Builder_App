const express = require('express');
const router = express.Router();
const db = require('../../db');
const { Console } = require('console');

router.get('/', async (req, res) => {
    try {
        const [cpu_coolers] = await db.query('SELECT cpu_cooler.id, model, manufacturer.name, fan_rpm, noise_level, height, water_cooled, price from cpu_cooler JOIN manufacturer ON manufacturer.id = cpu_cooler.manufacturer_id');
        const [compatibilities] = await db.query('SELECT cpu_cooler_compatibility.cooler_id,  cpu_socket.name from cpu_cooler_compatibility JOIN cpu_socket ON cpu_socket.id = cpu_cooler_compatibility.cpu_id ORDER BY cooler_id ASC');
        res.status(200).json({
            cpu_coolers: cpu_coolers,
            compatibilities: compatibilities
        });
    } catch (error) {
        console.error("SQL Error:", error); 
        res.status(500).json({ error: error.message }); 
    }
});

router.get('/:id', async (req, res) => {
    const { id } = req.params;
    try {
        const [cpu_cooler] = await db.query('SELECT cpu_cooler.id, model, manufacturer.name, fan_rpm, noise_level, height, water_cooled, price from cpu_cooler JOIN manufacturer ON manufacturer.id = cpu_cooler.manufacturer_id WHERE cpu_cooler.id = ?', [id]);
        const [compatibilities] = await db.query('SELECT cpu_cooler_compatibility.cooler_id,  cpu_socket.name from cpu_cooler_compatibility JOIN cpu_socket ON cpu_socket.id = cpu_cooler_compatibility.cpu_id WHERE cpu_cooler_compatibility.cooler_id = ? ORDER BY cooler_id ASC', [id]);
        res.status(200).json({
            cpu_coolers: cpu_cooler,
            compatibilities: compatibilities
        });
    } catch (error) {
        console.error("SQL Hiba:", error);
        res.status(500).json({ error: "Something went wrong" });
    }
});

module.exports = router;