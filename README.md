# Transits Tracker API

WebApi for tracking transits and generating reports based on added data.

[Inspiration](https://notehub.org/9pk10)

## Technologies

* .NET Core
* C#
* Entity Framework Core


## Getting started

Clone repository and build.

To have connection with Google Maps Distance Matrix API (required for dynamic distance calculations) [generate your private key](https://developers.google.com/maps/documentation/distance-matrix/).

Then paste it in file:

```
TransitsTracker.API/ExternalServices/GoogleMaps/GoogleMapsService.cs

private const string API_KEY = "your_api_key";
```

Created and built with **VS Enterprise 2017**.


## Documentation


### Transits


|   |   |
|---|---|
|**Title**|Get transits|
|**Description**|Returns all transits.|
|**URL**|/api/transits|
|**Method**|GET|
|**Data params**|None|
|**Params**|None|
|**Success**|**Example:** /api/transits<br>**Code:** 200<br>**Content:** |
|| `[` |
|| `    {` |
|| `        "source_address": {` |
|| `            "city": "Warszawa",` |
|| `            "street": "Poznańska",` |
|| `            "house_number": "3"` |
|| `        },` |
|| `        "destination_address": {` |
|| `            "city": "Poznan",` |
|| `            "street": "Bukowska",` |
|| `            "house_number": "15"` |
|| `        },` |
|| `        "price": 320,` |
|| `        "date": "2018-03-15T00:00:00",` | 
|| `        "distance": 310` |
|| `    },` |
|| `    ...` |
|| `]` |
|**Error**|todo|


|   |   |
|---|---|
|**Title**|Get transit|
|**Description**|Returns transit with requested id.|
|**URL**|/api/transits/:id|
|**Method**|GET|
|**Data params**|None|
|**Params**|**Required:** id [integer] |
|**Success**|**Example:** /api/transits/1/<br>**Code:** 200<br>**Content:** |
|| `    {` |
|| `        "source_address": {` |
|| `            "city": "Warszawa",` |
|| `            "street": "Poznańska",` |
|| `            "house_number": "3"` |
|| `        },` |
|| `        "destination_address": {` |
|| `            "city": "Poznan",` |
|| `            "street": "Bukowska",` |
|| `            "house_number": "15"` |
|| `        },` |
|| `        "price": 320,` |
|| `        "date": "2018-03-15T00:00:00",` | 
|| `        "distance": 310` |
|| `    }` |
|**Error**|todo|


|   |   |
|---|---|
|**Title**|Create new transit|
|**Description**|Creates new transit. Distance between given addresses is calculating automatically.|
|**URL**|/api/transits|
|**Method**|POST|
|**Data params**| |
|| `    {` |
|| `        "source_address": {` |
|| `            "city": "Warszawa",` |
|| `            "street": "Poznańska",` |
|| `            "house_number": "3"` |
|| `        },` |
|| `        "destination_address": {` |
|| `            "city": "Poznan",` |
|| `            "street": "Bukowska",` |
|| `            "house_number": "15"` |
|| `        },` |
|| `        "price": 320,` |
|| `        "date": "2018-03-15",` | 
|| `    }` |
|**Params**|**Required:** todo<br>**Optional:** todo |
|**Success**|**Example:** <br>**Code:** 200<br>**Content:** None
|**Error**|todo|


### Reports

#### Daily

|   |   |
|---|---|
|**Title**|Get daily report|
|**Description**|Returns number of kilometers traveled and the money earned between the two dates.|
|**URL**|/api/reports/daily?start_date=:start_date&end_date=:end_date|
|**Method**|GET|
|**Data params**| todo |
|**Params**|**Required:** start_date [date], end_date [date] |
|**Success**|**Example:** api/reports/daily?start_date=2018-03-10&end_date=2018-03-15<br>**Code:** 200<br>**Content:** |
|| `{ ` |
|| `  "total_distance": 310,` |
|| `  "total_price": 320.00` |
|| `}` |
|**Error**|todo|


#### Monthly

|   |   |
|---|---|
|**Title**|Get monthly report|
|**Description**|Returns the number of kilometers traveled, the average distance and the average payment for each day in current month|
|**URL**|/api/reports/monthly|
|**Method**|GET|
|**Data params**|None|
|**Params**|None|
|**Success**|**Example:** /api/reports/monthly<br>**Code:** 200<br>**Content:**
|| ` {` |
|| ` "items": [` |
|| `   {` |
|| `     "date": "2018-04-01T00:00:00",` |
|| `     "total_distance": 0,` |
|| `     "avg_distance": 0.0,` |
|| `     "avg_price": 0.0` |
|| `   }` |
|| `  ]` |
|| ` }` |
|**Error**|todo|


## External Services

* Google Maps Distance Matrix API


## Testing

* xUnit - In progress.


## Versioning

* Git


## Authors

[Jakub Wajs](https://github.com/kubawajs)
