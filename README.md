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
|**Title**|Returns all transits|
|**URL**|/transits|
|**Method**|GET|
|**Data params**|None|
|**Params**|None|
|**Success**|**Example:** todo **Code:** todo **Content:** { todo }
||**Example:** Empty list **Code:** 204 **Content:**
|**Error**|todo|
|**Notes**||


|   |   |
|---|---|
|**Title**|Returns transit with requested id|
|**URL**|/transits/:id|
|**Method**|GET|
|**Data params**|None|
|**Params**|**Required:** id [integer] |
|**Success**|**Example:** todo **Code:** todo **Content:** { todo }
|**Error**|todo|
|**Notes**||


|   |   |
|---|---|
|**Title**|Creates new transit|
|**URL**|/transits|
|**Method**|POST|
|**Data params**| todo |
|**Params**|**Required:** todo **Optional:** todo |
|**Success**|**Example:** todo **Code:** todo **Content:** { todo }
|**Error**|todo|
|**Notes**||


### Reports

#### Daily

|   |   |
|---|---|
|**Title**|Returns number of kilometers traveled and the money earned between the two dates.|
|**URL**|/daily?start_date=:start_date&end_date=:end_date|
|**Method**|GET|
|**Data params**| todo |
|**Params**|**Required:** start_date [date], end_date [date] |
|**Success**|**Example:** todo **Code:** todo **Content:** { todo } |
|**Error**|todo|
|**Notes**||

#### Monthly

|   |   |
|---|---|
|**Title**|
Returns the number of kilometers traveled, the average distance and the average payment for each day in current month|
|**URL**|/monthly|
|**Method**|GET|
|**Data params**|todo|
|**Params**|None|
|**Success**|**Example:** todo **Code:** todo **Content:** { todo }
|**Error**|todo|
|**Notes**||


## External Services

* Google Maps Distance Matrix API


## Testing

xUnit - In progress.


## Versioning

Git


## Authors

Jakub Wajs
