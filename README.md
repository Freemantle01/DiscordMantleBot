# DiscordMantleBot
Bot for discord


Docker 
cd to the path where is the Dockerfile
docker build --tag discordmantlebot -f  Dockerfile ..
docker run -d -v F:/discord_bot/net5/bot_token:/app/bot_token -v F:/discord_bot/net5/ylyl:/app/ylyl discordmantlebot
docker run -d --name DiscordMantleBot -v F:/discord_bot/net5/bot_token:/app/bot_token -v F:/discord_bot/net5/ylyl:/app/ylyl discordmantlebot

Check if it's running
docker logs DiscordMantleBot
