## Validate — валидность режима

Проверка корректности режима и сообщение об ошибке с закрытием комнаты.

Основное:
- `Validate.IsValid` (nullable bool), `Validate.Message`
- `Validate.ReportInvalid("Localized/Key")` — сообщить о невалидности (комната закроется)
- `Validate.ReportValid()` — прекратить учёт последующих репортов
- Событие: `Validate.OnValid`

