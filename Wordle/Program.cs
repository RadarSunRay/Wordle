using Wordle;

ISetting setting = new Setting();
IRandom random = new MyRandom();
GameEngine gameLogger = new GameEngine(setting, random);
gameLogger.Game();
