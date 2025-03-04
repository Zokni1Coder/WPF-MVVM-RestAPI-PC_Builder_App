const express = require('express');
const router = express.Router();
const db = require('../../db');

router.get('/', async (req, res) => {
    try {
        const [rows] = await db.query('SELECT motherboard.id, manufacturer.name AS manufacturer, motherboard.info, cpu_socket.name AS socket, form_factor_motherboard.form AS form_factor, motherboard_chipset.name AS chipset, motherboard.memory_max, ram_types.type AS ram_type, motherboard.memory_slots_no, motherboard.sata_60gbs_no, motherboard.onboard_ethernet, motherboard.wifi, motherboard.raid_supp, motherboard.price FROM motherboard JOIN manufacturer ON motherboard.manufacturer_id = manufacturer.id JOIN form_factor_motherboard ON motherboard.form_factor_id = form_factor_motherboard.id JOIN cpu_socket ON motherboard.socket_id = cpu_socket.id JOIN motherboard_chipset ON motherboard.chipset_id = motherboard_chipset.id JOIN ram_types ON motherboard.memory_type_id = ram_types.id');
        res.status(200).json(rows);
    } catch (error) {
        console.error("SQL Error:", error); 
        res.status(500).json({ error: error.message }); 
    }
});

router.get('/:id', async (req, res) => {
    const { id } = req.params;
    try {
        const [rows] = await db.query('SELECT motherboard.id, manufacturer.name AS manufacturer, motherboard.info, cpu_socket.name AS socket, form_factor_motherboard.form AS form_factor, motherboard_chipset.name AS chipset, motherboard.memory_max, ram_types.type AS ram_type, motherboard.memory_slots_no, motherboard.sata_60gbs_no, motherboard.onboard_ethernet, motherboard.wifi, motherboard.raid_supp, motherboard.price FROM motherboard JOIN manufacturer ON motherboard.manufacturer_id = manufacturer.id JOIN form_factor_motherboard ON motherboard.form_factor_id = form_factor_motherboard.id JOIN cpu_socket ON motherboard.socket_id = cpu_socket.id JOIN motherboard_chipset ON motherboard.chipset_id = motherboard_chipset.id JOIN ram_types ON motherboard.memory_type_id = ram_types.id WHERE motherboard.id = ?', [id]);

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