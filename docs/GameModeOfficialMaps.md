# оффициальные списки карт для режима

Тут описано как и зачем задавать официальные списки карт для своего режима:

обращаем внимание, что таких списков можно указывать много.
Иногда это полезно, чтобы разделить карты например на маленькие, средние и большие. Или хорошо, что владелец списка занимается поиском и добавлением карт, под Ваш режим.

пример части файла gamemode.json:
```json
  "MapLists": [
    {
      "MapListId": 324,
      "Name": "Официальные карты"
    },
    {
      "MapListId": 581
    }
  ]
```
В примере выше задается 2 оффициальных списка для режима.
Причем список 324 в этом режиме отображаться будет подругому - его имя в режиме будет изменено на "Официальные карты", тк задано поле Name.
Если поле Name не задано то список будет именоваться так, как это задавал создатель списка.
Второй список (581) будет именоваться также как он сам и назван
Это сделано для того, чтобы один и тотже список карт можно было по-разному отображать в разных игровых режимах
