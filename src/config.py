import os

from pathlib import Path
from nextcord import Color, Intents
from nextcord.ext import commands

# Set environment vars
_remote = True

if Path(".\\src\\env.py").is_file():
    import env

    _remote = env.reg_environ()

# Bot/Server
REMOTE = _remote
SRC: str = os.environ["SRC"]

SERVER_ID: int = 900439680053551114
# BACKEND_SERVER_ID: int = 974478383289364560

BOT = commands.Bot(command_prefix=("--", "—"), intents=Intents.all())
BOT_NAME = "Farin"
BOT_STATUS = "just watching..."

# Images
IMG_NOTICE = "https://cdn.discordapp.com/attachments/954237048275996693/954817191998546000/notice.png"
IMG_INVALID = "https://cdn.discordapp.com/attachments/954237048275996693/954817192678010911/invalid.png"
IMG_WARNING = "https://cdn.discordapp.com/attachments/954237048275996693/954817192199847936/warning.png"
IMG_HELP = "https://cdn.discordapp.com/attachments/954237048275996693/954817192426360952/help.png"
IMG_ACESS_DENIED = "https://cdn.discordapp.com/attachments/954237048275996693/954893350878724118/access_denied.png"

# System Colours
COLOR_NOTICE = Color(0x33DD85)
COLOR_INVALID = Color(0xE03F5A)
COLOR_WARNING = Color(0xEDC740)
COLOR_HELP = Color(0x57A3ED)
COLOR_BLUE = Color(0x57A3ED)

# Emojis
EMOJI_BIN_IT = "<:bin_it:954816024736329739>"

# Roles
# ROLE_OWNER: int = 954593155737616394
ROLE_ADMIN: int = 900440730982547517
ROLE_MODERATOR: int = 900841305167507498
ROLE_MEMBER: int = 900842055213912084

# Static Channels
SC_TOPIC_REQUESTS: int = 955011409018757150
CHANNEL_WELCOME: int = 900449427590893608
CHANNEL_GENERAL: int = 903008587327082616

HC_ROLEMENUS = {
    903006819172118669: {
        "🗒️": 902989321743781889,
        "📝": 902770439351324694,
        "🎨": 902990595243532308,
    },
    903016230863118396: {
        "✏️": 902993263999451157,
        "📝": 902993643302952991,
        "📌": 902993164397334568,
    },
}
