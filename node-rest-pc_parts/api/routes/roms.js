const express = require('express');
const router = express.Router();
const db = require('../../db');

router.get('/', async (req, res) => {
    try {
        const [roms] = await db.query('SELECT rom.id, rom.model, manufacturer.name, rom.capacity, rom_types.type, rom_form_factor.form_factor, rom.nvme, rom.rpm, rom_interfaces.interface, rom.price FROM rom JOIN manufacturer ON manufacturer.id = rom.manufacturer_id JOIN rom_types ON rom_types.id = rom.type JOIN rom_form_factor ON rom_form_factor.id = rom.form_factor JOIN rom_interfaces ON rom_interfaces.id = rom.interface');
        res.status(200).json(roms);
    } catch (error) {
        console.error("SQL Error:", error); 
        res.status(500).json({ error: error.message }); 
    }
});

router.get('/:id', async (req, res) => {
    const { id } = req.params;
    try {
        const [rom] = await db.query('SELECT rom.id, rom.model, manufacturer.name, rom.capacity, rom_types.type, rom_form_factor.form_factor, rom.nvme, rom.rpm, rom_interfaces.interface, rom.price FROM rom JOIN manufacturer ON manufacturer.id = rom.manufacturer_id JOIN rom_types ON rom_types.id = rom.type JOIN rom_form_factor ON rom_form_factor.id = rom.form_factor JOIN rom_interfaces ON rom_interfaces.id = rom.interface WHERE rom.id = ?', [id]);
        res.status(200).json(rom);
    } catch (error) {
        console.error("SQL Hiba:", error);
        res.status(500).json({ error: "Something went wrong" });
    }
});

module.exports = router;