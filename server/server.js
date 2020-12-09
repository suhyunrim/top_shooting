const dotenv = require('dotenv');
dotenv.config();

const express = require('express');
const app = express();
const port = process.env.PORT || 3000;
const bodyParser = require('body-parser');
app.use(bodyParser.urlencoded({ extended: true }));

const mysql = require('mysql');
const connection = mysql.createConnection({
  host     : process.env.DB_HOST,
  user     : process.env.DB_USERNAME,
  password : process.env.DB_PASSWORD,
  database : 'top_shooting'
});
connection.connect();

app.get('/', (req, res) => {
    res.json({
        success: true,
    });
});

app.get('/ranking', (req, res) => {
    const rankings = [];

    connection.query(`SELECT * FROM userscores;`, (error, results, fields) => {
        if (error) {
            console.log(error);
        }

        console.log(results);

        results.sort((a, b) => b.score - a.score);

        res.json(results);
    });
});

app.post('/registerScore', (req, res, next) => {
    var name = req.body.name;
    var score = req.body.score;

    connection.query(`INSERT INTO userscores VALUES ('${name}', ${score}) ON DUPLICATE KEY UPDATE score = ${score};`, (error, results, fields) => {
        if (error) {
            console.log(error);
        }

        console.log(results);
    });

    res.json({success: true});
});

app.listen(port, () => {
    console.log(`server is listening at localhost:${port}`);
});