from re import L
from config import ROLE_ADMIN, EMOJI_2COOL1
from utils import load_json, has_role, save_json
from nextcord.ext import commands


class Links(commands.Cog):
    """Handles and censors content posted by users"""

    def __init__(self, bot: commands.Bot):
        self.bot = bot
        self.links = load_json("media_links")

    @commands.command()
    async def link(self, ctx: commands.Context, name):
        await ctx.message.delete()
        await ctx.channel.send(self.links[name])

    @commands.command(aliases=["add-link"])
    async def addlink(self, ctx: commands.Context, name, link):

        if not await has_role(ctx.message.author, [ROLE_ADMIN], ctx.message):
            return

        self.links[name] = link
        save_json("media_links", self.links)
        await ctx.message.add_reaction(EMOJI_2COOL1)

    @commands.command(aliases=["remove-link"])
    async def removelink(self, ctx: commands.Context, name):

        if not await has_role(ctx.message.author, [ROLE_ADMIN], ctx.message):
            return

        try:
            self.links.pop(name)
            save_json("media_links", self.links)
            await ctx.message.add_reaction(EMOJI_2COOL1)
        except:
            return


def setup(bot: commands.Bot):
    bot.add_cog(Links(bot))
