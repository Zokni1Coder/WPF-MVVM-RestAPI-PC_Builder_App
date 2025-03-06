const express = require('express');
const router = express.Router();
const db = require('../../db');

router.get('/', async (req, res) => {
    try {
        const [motherboards] = await db.query('SELECT motherboard.id, manufacturer.name AS manufacturer, motherboard.info, cpu_socket.name AS socket, form_factor_motherboard.form AS form_factor, motherboard_chipset.name AS chipset, motherboard.memory_max, ram_types.type AS ram_type, motherboard.memory_slots_no, motherboard.sata_60gbs_no, motherboard.onboard_ethernet, motherboard.wifi, motherboard.raid_supp, motherboard.price FROM motherboard JOIN manufacturer ON motherboard.manufacturer_id = manufacturer.id JOIN form_factor_motherboard ON motherboard.form_factor_id = form_factor_motherboard.id JOIN cpu_socket ON motherboard.socket_id = cpu_socket.id JOIN motherboard_chipset ON motherboard.chipset_id = motherboard_chipset.id JOIN ram_types ON motherboard.memory_type_id = ram_types.id');
        const [m2s] =  await db.query('SELECT motherboard_m2type_connection.id, motherboard, rom_form_factor.form_factor FROM `motherboard_m2type_connection` JOIN rom_form_factor ON rom_form_factor.id = m2_form');
        const [usb_headers] = await db.query('SELECT motherboard_id, usb_version.version, header_count FROM motherboard_usb_headers JOIN usb_version ON usb_version.id = motherboard_usb_headers.usb_version_id ORDER BY motherboard_usb_headers.id ASC');

        res.status(200).json({
            motherboards: motherboards,
            m2types: m2s,
            usb_headers: usb_headers
        });
    } catch (error) {
        console.error("SQL Error:", error); 
        res.status(500).json({ error: error.message }); 
    }
});

router.get('/:id', async (req, res) => {
    const { id } = req.params;
    try {
        const [motherboards] = await db.query('SELECT motherboard.id, manufacturer.name AS manufacturer, motherboard.info, cpu_socket.name AS socket, form_factor_motherboard.form AS form_factor, motherboard_chipset.name AS chipset, motherboard.memory_max, ram_types.type AS ram_type, motherboard.memory_slots_no, motherboard.sata_60gbs_no, motherboard.onboard_ethernet, motherboard.wifi, motherboard.raid_supp, motherboard.price FROM motherboard JOIN manufacturer ON motherboard.manufacturer_id = manufacturer.id JOIN form_factor_motherboard ON motherboard.form_factor_id = form_factor_motherboard.id JOIN cpu_socket ON motherboard.socket_id = cpu_socket.id JOIN motherboard_chipset ON motherboard.chipset_id = motherboard_chipset.id JOIN ram_types ON motherboard.memory_type_id = ram_types.id WHERE motherboard.id = ?', [id]);
        const [m2s] =  await db.query('SELECT motherboard_m2type_connection.id, motherboard, rom_form_factor.form_factor FROM `motherboard_m2type_connection` JOIN rom_form_factor ON rom_form_factor.id = m2_form where motherboard = ?', [id]);
        const [usb_headers] = await db.query('SELECT motherboard_id, usb_version.version, header_count FROM motherboard_usb_headers JOIN usb_version ON usb_version.id = motherboard_usb_headers.usb_version_id WHERE motherboard_id = ?', [id]);

        res.status(200).json({
            motherboard: motherboards[0],
            m2s: m2s,
            usb_headers: usb_headers
        });
    } catch (error) {
        console.error("SQL Hiba:", error);
        res.status(500).json({ error: "Something went wrong" });
    }
});

module.exports = router;