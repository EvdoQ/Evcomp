# Evcomp

## Описание проекта

Evcomp — это веб-приложение для размещения готовых компьютеров и подбора комплектующих при помощи конфигуратора. Проект разработан на ASP.NET Core 8.0 с использованием Entity Framework и базы данных PostgreSQL. 

Сайт: https://evcomp.ru/

Frontend код:  https://github.com/EvdoQ/evcomp-frontend
## Реализованные пункты:
- [x] CRUD операции над сущностью компьютер: 
	- [x] Получение компьютера по `id` и получение всего списка компьютеров 
	- [x] Создание компьютера с загрузкой изображения в S3 хранилище 
	- [x] Обновление компьютера 
	- [x] Удаление компьютера 
- [x] Аутентификация и авторизация 
- [x] Хранение изображений компьютеров в S3 хранилище, которое реализовано в виде отдельного сервиса 
- [x] Разделение проекта на трехуровневую архитектуру, с уровнями `PresentationLayer`, `BusinessLayer` и `DataAccessLayer` 
- [x] Использование Docker и Docker-compose для контейнеризации проекта 
- [x] Настройка деплоя на VDS-сервер и использованием Nginx, установка SSL-сертификата и подключение домена 
## TODO
- [ ] Написаны юнит-тесты для всей бизнес-логики
- [ ] Реализован конфигуратор
- [ ] Настроен CI/CD
- [ ] Реализован telegram-бот
- [ ] Реализован сервис уведомлений
## Технологии
- **Backend:** ASP.NET Core 8.0
- **Frontend:** React (TypeScript)
- **ORM:** Entity Framework Core
- **База данных:** PostgreSQL
- **Файловое хранилище:** AWS S3
- **Сервер:** VPS с Nginx

## Запуск проекта локально
`В процессе`