const express = require('express');
const router = express.Router();
const db = require('../../db');

router.get('/', async (req, res) => {
    try {
        const [cpus] = await db.query('SELECT cpu.id, manufacturer.name AS manufacturer, cpu_series.name AS series, cpu.model, cpu_microarchitecture.name AS microarchitecture, cpu_socket.name AS socket, cpu.core_count, cpu.thread_count, cpu.core_clock, cpu.boost_core_clock, cpu.L2_cache, cpu.L3_cache, cpu.tdp, integrated_graphics.model AS integrated_graphics, cpu.price from cpu JOIN cpu_series ON cpu_series.id = cpu.series_id JOIN cpu_microarchitecture ON cpu_microarchitecture.id = cpu.microarchitecture_id JOIN cpu_socket ON cpu_socket.id = cpu.socket_id JOIN manufacturer ON cpu_series.manufacturer_id = manufacturer.id LEFT JOIN integrated_graphics ON integrated_graphics.id = cpu.integrated_gpu_id');
        res.status(200).json(cpus);
    } catch (error) {
        console.error("SQL Error:", error); 
        res.status(500).json({ error: error.message }); 
    }
});

router.get('/:id', async (req, res) => {
    const { id } = req.params;
    try {
        const [cpu] = await db.query('SELECT cpu.id, manufacturer.name AS manufacturer, cpu_series.name AS series, cpu.model, cpu_microarchitecture.name AS microarchitecture, cpu_socket.name AS socket, cpu.core_count, cpu.thread_count, cpu.core_clock, cpu.boost_core_clock, cpu.L2_cache, cpu.L3_cache, cpu.tdp, integrated_graphics.model AS integrated_graphics, cpu.price from cpu JOIN cpu_series ON cpu_series.id = cpu.series_id JOIN cpu_microarchitecture ON cpu_microarchitecture.id = cpu.microarchitecture_id JOIN cpu_socket ON cpu_socket.id = cpu.socket_id JOIN manufacturer ON cpu_series.manufacturer_id = manufacturer.id LEFT JOIN integrated_graphics ON integrated_graphics.id = cpu.integrated_gpu_id WHERE cpu.id = ?', [id]);
        res.status(200).json(cpu);
    } catch (error) {
        console.error("SQL Hiba:", error);
        res.status(500).json({ error: "Something went wrong" });
    }
});

module.exports = router;