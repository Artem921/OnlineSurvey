## <sup> Проект релизован в качестве демонстрации api приложения, для  анонимного онлайн опроса. </sup>
### Запуск проекта.
#### Через терминал пройдиет в корневую папку проекта и запустите команду:
```
docker-compose up
```
#### Если в конце сборки образа получите ошибку:
```
System.InvalidOperationException: Unable to configure HTTPS endpoint. No server certificate was specified, and the default developer certificate could not be found or is out of date.
```

#### Стек проекта:
+ <sup> Asp Net Core Web Api </sup>
+ <sup> Docker </sup>
+ <sup> Entity Framework </sup>
+ <sup> PostgresSQL </sup>

## <sup> Архитектура </sup>
### <sup> Монолит потроенный на трёхслойной архитектуре. </sup>
+ <sup> .Infrastructure - Здесь вся работа с данными.</sup>
+ <sup> .Domain - Ядро приложени.</sup>
+ <sup> .Application - Здесь Бизнес логика. </sup>
+ <sup> .Api - Уровень представления </sup>
