# webapi-psdtu

Задача:
сделать web API на .NET 8, 
подключить базу данных PosgreSQL, 
сделать 1-2 эндпоинта для выдачи данныхиз базы в формате .JSON,
вывести интерфейс управления в браузере
собрать проект в Docker

===========================================================================

Как включить:

1. Запустить Docekr.
2. Поместить postgeres-ddata.tar.gz (данными для БД PostgreSQL в докере) и docker-compose.yml (параметры запуска докера) в отдельную папку и открыть ее в терминале.
                                                                                                                            (ну мб можно и в осовной директории)
4. Выполнить команды:
   docker volume create postgress-ddata
   docker run --rm -v postgress-ddata:/data -v ${PWD}:/backup ubuntu bash -c "cd /data && tar xzf /backup/postgress-ddata.tar.gz"
   docker-compose up
5. Перейти по ссылке: http://localhost:5101/swagger/index.html
