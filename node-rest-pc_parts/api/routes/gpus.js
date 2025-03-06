const express = require('express');
const router = express.Router();
const db = require('../../db');

router.get('/', async (req, res) => {
    try {
        const [gpus] = await db.query('SELECT gpu.id, gpu.info, manufacturer.name as manufacturer, brands.brand, gpu_technology.technology, gpu.model, gpu.vram, ram_types.type AS ram_type, gpu.core_clock, gpu.boost_clock, pci_slot_type.name AS interface, frame_syncs.sync AS frame_sync, gpu.tdp, gpu.hdmi_ouput, gpu.dp_port_output, gpu.price FROM gpu  JOIN manufacturer ON manufacturer.id = gpu.manufacturer JOIN brands ON brands.id = gpu.brand JOIN gpu_technology ON gpu_technology.id = gpu.technology JOIN ram_types ON ram_types.id = gpu.memory_type JOIN pci_slot_type ON pci_slot_type.id = gpu.interface JOIN frame_syncs ON frame_syncs.id = gpu.frame_sync');
        res.status(200).json(gpus);
    } catch (error) {
        console.error("SQL Error:", error); 
        res.status(500).json({ error: error.message }); 
    }
});

router.get('/:id', async (req, res) => {
    const { id } = req.params;
    try {
        const [gpu] = await db.query('SELECT gpu.id, gpu.info, manufacturer.name as manufacturer, brands.brand, gpu_technology.technology, gpu.model, gpu.vram, ram_types.type AS ram_type, gpu.core_clock, gpu.boost_clock, pci_slot_type.name AS interface, frame_syncs.sync AS frame_sync, gpu.tdp, gpu.hdmi_ouput, gpu.dp_port_output, gpu.price FROM gpu  JOIN manufacturer ON manufacturer.id = gpu.manufacturer JOIN brands ON brands.id = gpu.brand JOIN gpu_technology ON gpu_technology.id = gpu.technology JOIN ram_types ON ram_types.id = gpu.memory_type JOIN pci_slot_type ON pci_slot_type.id = gpu.interface JOIN frame_syncs ON frame_syncs.id = gpu.frame_sync WHERE gpu.id = ?', [id]);
        res.status(200).json(gpu);
    } catch (error) {
        console.error("SQL Hiba:", error);
        res.status(500).json({ error: "Something went wrong" });
    }
});

module.exports = router;