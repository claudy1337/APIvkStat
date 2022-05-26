APIvkStat V5.131
===========
API ВКонтакте — это интерфейс, который позволяет получать информацию из базы данных vk.com с помощью http-запросов к специальному серверу
```
{
  "response": [
    {
      "id": 210700286,
      "first_name": "Aboba",
      "last_name": "Boba"
    }
  ]
}
```
самым простым способом (Implicit flow) и получить токен для работы с API из созданного приложения.
APP_ID
```
https://oauth.vk.com/authorize?client_id=5490057&display=page&redirect_uri=https://oauth.vk.com/blank.html&scope=friends&response_type=token&v=5.131
```

| TOKEN | KEY | ID |
|----------------|:---------:|----------------:|
| коды доступа | ключи доступа | индефикаторы |
| USER_TOKEN | PROTECTED_KEY | USER_ID |
| ACCES_TOKEN | ACCES_KEY_GROUP  | APP_ID |
| APP_TOKEN | APP_KEY | ACCES_ID |
