# Sprendžiamo uždavinio aprašymas

## Sistemos paskirtis

Projekto tikslas – sistema (WEB aplikacija + API), suburanti maisto gaminimu besidominčius žmones. Sistema leidžia įkelti naujus receptus, ieškoti receptų, bei dalintis receptais su bendraminčiais.

Veikimo principas – sistema sudaryta iš 2 dalių. Pirmoji – WEB aplikacija, kurią naudotojas gali pasiekti iš bet kokio įrenginio, turinčio galimybę naršyti internete bei turintį prieigą prie interneto. Antroji – API dalis, skirta apdoroti visas užklausas ir atsakinga už „logiką”.

Naudotojui norint naudotis sistema, pirmiausia reikia užsiregistruoti. Tą atlikęs, jis galės naršyti po kitų naudotojų įkeltus receptus, pridėti savo receptus. Administratorius gali pridėti, redaguoti, ištrinti receptų kategorijas bei pačius receptus.Taip pat gali blokuoti naudotojus.
Egzistuoja 3 pagrindinės esybės – ingredientas, patiekalas, kategorija. Patiekalas susideda iš ingredientų, patiekalai priklauso kategorijoms.

## Funkciniai reikalavimai

<b>Neregistruotas</b> sistemos naudotojas gali:
1. Peržiūrėti platformos reprezentacinį puslapį.
2. Prisijungti prie internetinės aplikacijos.

<b>Registruotas</b> sistemos naudotojas gali:
1. Atsijungti nuo internetinės aplikacijos.
2. Prisijungti (užsiregistruoti) prie platformos.
3. Pridėti naują receptą.
4. Redaguoti pridėtą receptą.
5. Ištrinti pridėtą receptą.
6. Pridėti/redaguoti/ištrinti ingredientus.
7. Ieškoti egzistuojančių receptų pagal kategoriją.
8. Išsaugoti patikusius receptus.

<b>Administratorius</b> gali:
1. Pridėti naują kategoriją.
2. Redaguoti egzistuojančią kategoriją.
3. Ištrinti esamą kategoriją.
4. Šalinti naudotojus.
5. Šalinti netinkamus receptus.

# Sistemos architektūra

Sistemos sudedamosios dalys:
1. Kliento pusė - naudojant Angular.
2. Serverio pusė - naudojant .NET Core. Duomenų bazė - MySQL.

![image](https://user-images.githubusercontent.com/67747616/208976500-ecdc7b23-924a-4b8d-935e-4c07c1a33644.png)

# Naudotojo sąsajos projektas

## Prisijungimo langas
1. Prototipas

![image](https://user-images.githubusercontent.com/67747616/208983111-58eaff1d-5133-47f9-9921-8bde9a296263.png)

2. Realizacija

![image](https://user-images.githubusercontent.com/67747616/208983195-1a4acc86-a5f9-4b2d-9fea-40337e0f2840.png)

## Registracijos langas
1. Prototipas

![image](https://user-images.githubusercontent.com/67747616/208984482-3008d22d-53c5-4602-8f59-4953caa35e19.png)

2. Realizacija

![image](https://user-images.githubusercontent.com/67747616/208984573-97d15707-b24e-415b-8981-2f5d3e74780a.png)

## Kategorijų langas
1. Prototipas

![image](https://user-images.githubusercontent.com/67747616/208988370-07a8888d-f718-48e5-bd27-091f6022fe15.png)

2. Realizacija

![image](https://user-images.githubusercontent.com/67747616/208988442-3dd772bd-8d92-4b6e-9da5-eaaaaa7eae84.png)

## Receptų langas

1. Prototipas

![image](https://user-images.githubusercontent.com/67747616/208989866-e2946a13-b993-4877-bfdb-53188e106b80.png)

2. Realizacija

![image](https://user-images.githubusercontent.com/67747616/208989948-c638be8b-3dbd-41f8-aa60-f2a522a4ecfa.png)

## Ingredientų langas

1. Prototipas

![image](https://user-images.githubusercontent.com/67747616/208990956-4ddd4b1b-1cdb-4398-9d4a-4252842afecb.png)

2. Realizacija

![image](https://user-images.githubusercontent.com/67747616/208991025-0df58298-03a0-4f40-991a-6ad727fe570a.png)


# API specifikacija

## Auth

<b>POST api/v1/register</b>


| Parameter     | Type          | Required  |
| ------------- |:-------------:|:---------:|
| userName      | string        |   yes     |
| email         | string        |   yes     |
| password      | string        |   yes     |

Example request:

`
    {
      "userName": "string",
      "email": "string",
      "password": "string"
    }
`

Example response:

`
{
  "id": "0a2de2ff-bcbf-4869-9e35-e1da7b6c5497",
  "userName": "Test123123",
  "email": "random@gmail.com"
}
`

<b>POST api/v1/login</b>


| Parameter     | Type          | Required  |
| ------------- |:-------------:|:---------:|
| userName      | string        |   yes     |
| password      | string        |   yes     |

Example request:

`
    {
      "userName": "string",
      "password": "string"
    }
`

Example response:

`
{
  "accessToken": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiYWRtaW4iLCJqdGkiOiI0OGFjOTE1Yi0xMzU5LTQ1ZjAtOWYzNC05ZDA3NzY2ODRhNDYiLCJzdWIiOiI4ODhlYjYzOC1jYjdhLTRmZWItOWQyYS0zNzQ4YjBlM2JiYWUiLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOlsiVXNlciIsIkFkbWluIl0sImV4cCI6MTY3MTY2MTI2OSwiaXNzIjoiRXJpa2FzIiwiYXVkIjoiVHJ1c3RlZENsaWVudCJ9._zYVDTohqiqSlpwVNYlPJXbE5Ku1XH9T5KKgAG60P9A"
}
`

## Categories

<b>GET api/v1/categories</b>

Example response:

`
[
  {
    "id": 1,
    "name": "Lithuanian dishes",
    "description": "Food from Lithuania",
    "creationDate": "2022-11-13T12:19:51.8224695"
  },
  {
    "id": 2,
    "name": "Italian dishes",
    "description": "Italian cuisine",
    "creationDate": "2022-11-14T15:36:07.1802952"
  }
]
`

<b>POST api/v1/categories</b>


| Parameter     | Type          | Required  |
| ------------- |:-------------:|:---------:|
| name          | string        |   yes     |
| description   | string        |   yes     |

Example request:

`
{
  "name": "Breakfast",
  "description": "Morning meals to start the day on a high note"
}
`

Example response:

`
{
    "id": 19,
    "name": "Breakfast",
    "description": "Morning meals to start the day on a high note",
    "creationDate": "2022-12-21T21:28:51.9479192Z"
}
`

<b>GET api/v1/categories/{categoryId}</b>


| Parameter     | Type          | Required  |
| ------------- |:-------------:|:---------:|
| categoryId    | int           |   yes     |

Example response:

`
{
  "id": 1,
  "name": "Lithuanian dishes",
  "description": "Food from Lithuania",
  "creationDate": "2022-11-13T12:19:51.8224695"
}
`

<b>PUT api/v1/categories/{categoryId}</b>


| Parameter     | Type          | Required  |
| ------------- |:-------------:|:---------:|
| categoryId    | int           |   yes     |
| description   | string        |   yes     |

Example request:

`
{
  "description": "updated!"
}
`

Example response:

`
{
    "id": 1,
    "name": "Lithuanian dishes",
    "description": "updated!",
    "creationDate": "2022-11-13T12:19:51.8224695"
}
`

<b>DELETE api/v1/categories/{categoryId}</b>


| Parameter     | Type          | Required  |
| ------------- |:-------------:|:---------:|
| categoryId    | int           |   yes     |

## Recipes

<b>GET api/v1/categories/{categoryId}/recipes</b>

| Parameter     | Type          | Required  |
| ------------- |:-------------:|:---------:|
| categoryId    | int           |   yes     |

Example response:

`
[
  {
    "id": 1,
    "name": "Pizza",
    "type": "Delicious pizza",
    "creationDate": "2022-12-12T22:17:28.7547352",
    "originCountry": "Italy",
    "timeToPrepare": 60,
    "portionsCount": 1,
    "isVegetarian": false,
    "isVegan": false
  },
  {
    "id": 2,
    "name": "Lasagna",
    "type": "Pasta dish",
    "creationDate": "2022-12-12T22:18:18.3195692",
    "originCountry": "Italy",
    "timeToPrepare": 120,
    "portionsCount": 3,
    "isVegetarian": false,
    "isVegan": false
  }
]
`

<b>POST api/v1/categories/{categoryId}/recipes</b>


| Parameter     | Type          | Required  |
| ------------- |:-------------:|:---------:|
| categoryId    | int           |   yes     |
| name          | string        |   yes     |
| type          | string        |   yes     |
| originCountry | string        |   yes     |
| timeToPrepare | int           |   yes     |
| portionsCount | int           |   yes     |
| isVegetarian  | boolean       |   yes     |
| isVegan       | boolean       |   yes     |


Example request:

`
{
  "name": "Boiled eggs",
  "type": "Breakfast",
  "originCountry": "-",
  "timeToPrepare": 15,
  "portionsCount": 1,
  "isVegetarian": true,
  "isVegan": false
}
`

Example response:

`
{
    "id": 14,
    "name": "Boiled eggs",
    "type": "Breakfast",
    "creationDate": "2022-12-21T22:07:00.5055901Z",
    "originCountry": "-",
    "timeToPrepare": 15,
    "portionsCount": 1,
    "isVegetarian": true,
    "isVegan": false
}
`

<b>GET api/v1/categories/{categoryId}/recipes/{recipeId}</b>


| Parameter     | Type          | Required  |
| ------------- |:-------------:|:---------:|
| categoryId    | int           |   yes     |
| recipeId      | int           |   yes     |

Example response:

`
{
  "id": 1,
  "name": "Pizza",
  "type": "Delicious pizza",
  "creationDate": "2022-12-12T22:17:28.7547352",
  "originCountry": "Italy",
  "timeToPrepare": 60,
  "portionsCount": 1,
  "isVegetarian": false,
  "isVegan": false
}
`

<b>PUT api/v1/categories/{categoryId}/recipes/{recipeId}</b>


| Parameter     | Type          | Required  |
| ------------- |:-------------:|:---------:|
| categoryId    | int           |   yes     |
| recipeId      | int           |   yes     |
| type          | string        |   yes     |
| originCountry | string        |   yes     |
| timeToPrepare | string        |   yes     |
| portionsCount | string        |   yes     |
| isVegetarian  | boolean       |   yes     |
| isVegan       | boolean       |   yes     |

Example request:

`
{
  "type": "string",
  "originCountry": "string",
  "timeToPrepare": 0,
  "portionsCount": 0,
  "isVegetarian": true,
  "isVegan": true
}
`

Example response:

`
{
  "id": 1,
  "name": "Pizza",
  "type": "string",
  "creationDate": "2022-12-12T22:17:28.7547352",
  "originCountry": "string",
  "timeToPrepare": 0,
  "portionsCount": 0,
  "isVegetarian": true,
  "isVegan": true
}
`

<b>DELETE api/v1/categories/{categoryId}/recipes/{recipeId}</b>


| Parameter     | Type          | Required  |
| ------------- |:-------------:|:---------:|
| categoryId    | int           |   yes     |
| recipeId      | int           |   yes     |

## Ingredients

<b>GET api/v1/categories/{categoryId}/recipes/{recipeId}/ingredients</b>

| Parameter     | Type          | Required  |
| ------------- |:-------------:|:---------:|
| categoryId    | int           |   yes     |
| recipeId      | int           |   yes     |

Example response:

`
[
  {
    "id": 8,
    "name": "Egg",
    "type": "Boiled",
    "isVegetarian": true,
    "isVegan": false
  }
]
`

<b>POST api/v1/categories/{categoryId}/recipes/{recipeId}/ingredients</b>


| Parameter     | Type          | Required  |
| ------------- |:-------------:|:---------:|
| categoryId    | int           |   yes     |
| recipeId      | int           |   yes     |
| name          | string        |   yes     |
| type          | string        |   yes     |
| isVegetarian  | boolean       |   yes     |
| isVegan       | boolean       |   yes     |


Example request:

`
{
  "name": "egg",
  "type": "dairy",
  "isVegetarian": true,
  "isVegan": false
}
`

Example response:

`
{
    "id": 9,
    "name": "egg",
    "type": "dairy",
    "isVegetarian": true,
    "isVegan": false
}
`

<b>GET api/v1/categories/{categoryId}/recipes/{recipeId}/ingredients/{ingredientId}</b>


| Parameter     | Type          | Required  |
| ------------- |:-------------:|:---------:|
| categoryId    | int           |   yes     |
| recipeId      | int           |   yes     |
| ingredientId  | int           |   yes     |

Example response:

`
{
    "id": 9,
    "name": "egg",
    "type": "dairy",
    "isVegetarian": true,
    "isVegan": false
}
`

<b>PUT api/v1/categories/{categoryId}/recipes/{recipeId}/ingredients/{ingredientId}</b>


| Parameter     | Type          | Required  |
| ------------- |:-------------:|:---------:|
| categoryId    | int           |   yes     |
| recipeId      | int           |   yes     |
| ingredientId  | int           |   yes     |
| name          | string        |   yes     |
| type          | string        |   yes     |
| isVegetarian  | boolean       |   yes     |
| isVegan       | boolean       |   yes     |

Example request:

`
{
  "name": "egg",
  "type": "dairy",
  "isVegetarian": true,
  "isVegan": false
}
`

Example response:

`
{
    "id": 9,
    "name": "egg",
    "type": "dairy",
    "isVegetarian": true,
    "isVegan": false
}
`

<b>DELETE api/v1/categories/{categoryId}/recipes/{recipeId}/ingredients/{ingredientId}</b>


| Parameter     | Type          | Required  |
| ------------- |:-------------:|:---------:|
| categoryId    | int           |   yes     |
| recipeId      | int           |   yes     |
| ingredientId  | int           |   yes     |


# Išvados
Sukurta WEB sistema. Pagilinau Angular žinias, taip pat išmokau daugiau apie aplikacijos deployment procesą.
