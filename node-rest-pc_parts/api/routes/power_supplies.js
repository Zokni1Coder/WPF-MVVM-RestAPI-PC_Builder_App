const express = require('express');
const router = express.Router();
const db = require('../../db');

router.get('/', async (req, res) => {
    try {
        const [pss] = await db.query('SELECT ps.id, ps.model, manufacturer.name AS manufacturer, power_supply_types.type, power_supply_ratings.rating, ps.wattage, power_supply_modularity.modularity, ps.wattage FROM power_supply AS ps JOIN manufacturer ON manufacturer.id = ps.manufacturer JOIN power_supply_types ON power_supply_types.id = ps.type JOIN power_supply_ratings ON power_supply_ratings.id = ps.efficiency_rating JOIN power_supply_modularity ON power_supply_modularity.id = ps.modularity');
        res.status(200).json(pss);
    } catch (error) {
        console.error("SQL Error:", error); 
        res.status(500).json({ error: error.message }); 
    }
});

router.get('/:id', async (req, res) => {
    const { id } = req.params;
    try {
        const [ps] = await db.query('SELECT ps.id, ps.model, manufacturer.name AS manufacturer, power_supply_types.type, power_supply_ratings.rating, ps.wattage, power_supply_modularity.modularity, ps.wattage FROM power_supply AS ps JOIN manufacturer ON manufacturer.id = ps.manufacturer JOIN power_supply_types ON power_supply_types.id = ps.type JOIN power_supply_ratings ON power_supply_ratings.id = ps.efficiency_rating JOIN power_supply_modularity ON power_supply_modularity.id = ps.modularity WHERE ps.id = ?', [id]);
        res.status(200).json(ps);
    } catch (error) {
        console.error("SQL Hiba:", error);
        res.status(500).json({ error: "Something went wrong" });
    }
});

module.exports = router;