# Banghay API

##Table of Contents

- [Banghay API](#banghay-api)
  - [Banghay API](#banghay-api-1)
  - [Create Module](#create-module)
    - [Create Module Request](#create-module-request)
    - [Create Module Response](#create-module-response)
  - [Get Module](#get-module)
    - [Get Module Request](#get-module-request)
    - [Get Module Response](#get-module-response)
  - [Update Module](#update-module)
    - [Update Module Request](#update-module-request)
    - [Update Module Response](#update-module-response)
  - [Delete Module](#delete-module)
    - [Delete Module Request](#delete-module-request)
    - [Delete Module Response](#delete-module-response)



## Banghay API
Hello! I created this API for Banghay. Banghay is a web application which would solve the problem for resource sharing between teachers to teachers and teachers to students. This API will help with the backend processes of the application. 

## Create Module

### Create Module Request

```js
POST /modules
```


```json 
{
    "name": "Hekasi Grade 1",
    "description": "History module for Grade 1 students.. ",
    "created by": "Test User 1",
    "startDateTime": "2022-11-28T08:00:00",
    "endDateTime": "2022-11-28T11:00:00",
    "tags": [
        "Hekasi",
        "History",
        "Grade 1",
        "Primary Education"
    ]
}
```

### Create Module Response

```js
201 Created
```

```yml
Location: {{ host }}/Modules/ {{ id }}
```

```json
{
    "id": "00000000-0000-0000-0000-00000000", /* Server-Generated */
    "name": "Hekasi Grade 1",
    "description": "History module for Grade 1 students.. ",
    "created by": "Test User 1",
    "startDateTime": "2022-11-28T08:00:00",
    "endDateTime": "2022-11-28T11:00:00",
    "lastModifiedDateTime": "22-04-06T12:00:00", /* Server-Generated */
    "tags": [
        "Hekasi",
        "History",
        "Grade 1",
        "Primary Education"
    ]
}
```
## Get Module

### Get Module Request

```js
GET /modules/{{ id }}
```
### Get Module Response

```js
200 Ok
```

```json
{
    "id": "00000000-0000-0000-0000-00000000", /* Server-Generated */
    "name": "Hekasi Grade 1",
    "description": "History module for Grade 1 students.. ",
    "created by": "Test User 1",
    "startDateTime": "2022-11-28T08:00:00",
    "endDateTime": "2022-11-28T11:00:00",
    "lastModifiedDateTime": "22-04-06T12:00:00", /* Server-Generated */
    "tags": [
        "Hekasi",
        "History",
        "Grade 1",
        "Primary Education"
    ]
}
```
## Update Module

### Update Module Request

```js
PUT /modules/{{ id }}
```
```json
{
    "name": "Hekasi Grade 1",
    "description": "History module for Grade 1 students.. ",
    "created by": "Test User 1",
    "startDateTime": "2022-11-28T08:00:00",
    "tags": [
        "Hekasi",
        "History",
        "Grade 1",
        "Primary Education"
    ]
}
```
### Update Module Response

```js
204 No Content
```

or

```js
201 Created
```

```yml
Location : {{ host }}/Modules/{{ id }}
```

## Delete Module

### Delete Module Request

```js
DELETE /modules/{{ id }}
```
### Delete Module Response

```js
204 No Content
```
