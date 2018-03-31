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
|**URL**|/transits|
|**Method**|GET|
|**Data params**|None|
|**Params**|None|
|**Success**|**Example:** todo<br>**Code:** todo<br>**Content:** { todo }
||**Example:** Empty list **Code:** 204 **Content:**
|**Error**|todo|


|   |   |
|---|---|
|**Title**|Get transit|
|**Description**|Returns transit with requested id.|
|**URL**|/transits/:id|
|**Method**|GET|
|**Data params**|None|
|**Params**|**Required:** id [integer] |
|**Success**|**Example:** todo<br>**Code:** todo<br>**Content:** { todo }
|**Error**|todo|


|   |   |
|---|---|
|**Title**|Create new transit|
|**Description**|Creates new transit. Distance between given addresses is calculating automatically.|
|**URL**|/transits|
|**Method**|POST|
|**Data params**| todo |
|**Params**|**Required:** todo<br>**Optional:** todo |
|**Success**|**Example:** todo<br>**Code:** todo<br>**Content:** { todo }
|**Error**|todo|


### Reports

#### Daily

|   |   |
|---|---|
|**Title**|Get daily report|
|**Description**|Returns number of kilometers traveled and the money earned between the two dates.|
|**URL**|/daily?start_date=:start_date&end_date=:end_date|
|**Method**|GET|
|**Data params**| todo |
|**Params**|**Required:** start_date [date], end_date [date] |
|**Success**|**Example:** todo<br>**Code:** todo<br>**Content:** { todo } |
|**Error**|todo|


#### Monthly

|   |   |
|---|---|
|**Title**|Get monthly report|
|**Description**|Returns the number of kilometers traveled, the average distance and the average payment for each day in current month|
|**URL**|/monthly|
|**Method**|GET|
|**Data params**|None|
|**Params**|None|
|**Success**|**Example:** todo<br>**Code:** todo<br>**Content:** { todo }
|**Error**|todo|


## External Services

* Google Maps Distance Matrix API


## Testing

* xUnit - In progress.


## Versioning

* Git


## Authors

[Jakub Wajs](https://github.com/kubawajs)
