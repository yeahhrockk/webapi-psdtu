# webapi-psdtu

Задача:
/nСделать web API на .NET 8, 
подключить базу данных PosgreSQL (минимум 3 связанные между собой таблицы), 
сделать эндпоинты для выдачи данных базы в формате .JSON, добавления удаления и редактирования уже существующих данных.
Вывести интерфейс управления в браузере,
собрать проект в Docker.

====================================================================================

Как включить:

1. Запустить Docekr.
2. Поместить **postgeres-ddata.tar.gz** (данные для БД PostgreSQL в докере) и **docker-compose.yml** (параметры запуска докера) в отдельную папку и открыть ее в терминале.
                                                                                                                                   (ну мб можно и в осовной директории)
4. Выполнить команды:
   `docker volume create postgres-ddata
   docker run --rm -v postgres-ddata:/data -v ${PWD}:/backup ubuntu bash -c "cd /data && tar xzf /backup/postgres-ddata.tar.gz"
   docker-compose up`
5. Перейти по ссылке: http://localhost:5101/swagger/index.html


Саша Крипак
