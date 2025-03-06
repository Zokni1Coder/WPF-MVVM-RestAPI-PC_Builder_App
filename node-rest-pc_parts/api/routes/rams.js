const express = require('express');
const router = express.Router();
const db = require('../../db');

router.get('/', async (req, res) => {
    try {
        const [rams] = await db.query('SELECT ram.id, ram.model, manufacturer.name, ram.speed, ram_types.type, ram.modul, ram.size, ram.cas_latency, ram.voltage, ram.price FROM ram JOIN manufacturer ON manufacturer.id = ram.manufacturer_id JOIN ram_types ON ram.slot_id = ram_types.id');
        res.status(200).json(rams);
    } catch (error) {
        console.error("SQL Error:", error); 
        res.status(500).json({ error: error.message }); 
    }
});

router.get('/:id', async (req, res) => {
    const { id } = req.params;
    try {
        const [ram] = await db.query('SELECT ram.id, ram.model, manufacturer.name, ram.speed, ram_types.type, ram.modul, ram.size, ram.cas_latency, ram.voltage, ram.price FROM ram JOIN manufacturer ON manufacturer.id = ram.manufacturer_id JOIN ram_types ON ram.slot_id = ram_types.id WHERE ram.id = ?', [id]);
        res.status(200).json(ram);
    } catch (error) {
        console.error("SQL Hiba:", error);
        res.status(500).json({ error: "Something went wrong" });
    }
});

module.exports = router;