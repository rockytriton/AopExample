
Do Get Request:
curl -D- http://localhost:5000/weatherforecast

Console log output:
Creating Read Transaction
FETCHING ALL
Committing Transaction

Do Post Request:
curl -X POST -d '{}' -H "Content-Type: application/json" http://localhost:5000/weatherforecast

Console log output:
Creating Write Transaction
OK INSERTING
Committing Transaction

