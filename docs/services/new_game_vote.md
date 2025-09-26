## NewGameVote — голосование за новую игру

Запуск голосования за новую игру и отслеживание результата.

Основное:
- `NewGameVote.Data`, `NewGameVote.Votes`, `NewGameVote.Result`, `NewGameVote.IsActive`, `NewGameVote.LapsedTime`
- `NewGameVote.Start({ Variants, Timer })`
- `NewGameVote.Start({ Variants, Timer }, extraVariantsCount)`
- События: `OnData`, `OnVote`, `OnResult`

Подойдёт для режимов выбора следующей карты. См. примеры ротации в [TDM](https://github.com/kkohno/PixelCombats.GameModes.TDM).

