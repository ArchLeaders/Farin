from config import IMG_HELP, COLOR_HELP
from typing import Optional, Set
from nextcord import Message
from nextcord.ext import commands

from config import BOT


class PunishmentCog(commands.Cog):
    """Ban, Kick and other server punishment commands"""

    def __init__(self, bot: commands.Bot):
        self.bot = bot


def setup(bot: commands.Bot):
    bot.add_cog(PunishmentCog(bot))
