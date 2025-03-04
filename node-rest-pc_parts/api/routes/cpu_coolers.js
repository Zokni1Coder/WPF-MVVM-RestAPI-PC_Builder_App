const express = require('express');
const router = express.Router();
const db = require('../../db');
const { Console } = require('console');

router.get('/', async (req, res) => {
    try {
        const [rows] = await db.query('SELECT cpu_cooler.id, model, manufacturer.name AS manufacturer, fan_rpm, noise_level, height, water_cooled, price FROM `cpu_cooler` JOIN manufacturer ON manufacturer.id = cpu_cooler.manufacturer_id');
        res.status(200).json(rows);
    } catch (error) {
        console.error("SQL Error:", error); 
        res.status(500).json({ error: error.message }); 
    }
});

router.get('/:id', async (req, res) => {
    const { id } = req.params;
    try {
        const [rows] = await db.query('SELECT cpu_cooler.id, model, manufacturer.name AS manufacturer, fan_rpm, noise_level, height, water_cooled, price FROM `cpu_cooler` JOIN manufacturer ON manufacturer.id = cpu_cooler.manufacturer_id WHERE cpu_cooler.id = ?', [id]);

        if (rows.length === 0) {
            return res.status(404).json({ error: "Not found anything" });
        }

        res.status(200).json({
            message: 'Success',
            motherboard: rows[0]
        });
    } catch (error) {
        console.error("SQL Hiba:", error);
        res.status(500).json({ error: "Something went wrong" });
    }
});

module.exports = router;