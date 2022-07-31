from nextcord.ext import commands
from config import ROLE_ADMIN, ROLE_MODERATOR
from utils import check


class CleanupCog(commands.Cog):
    """Various cleanup commands"""

    def __init__(self, bot: commands.Bot):
        self.bot = bot

    @commands.command()
    async def clear(self, ctx: commands.Context, limit="5"):
        """
        Clears a set amount of messages from the active channel.
        Use the 'all' parameter to clear 1K messages.
        """

        # Check roles
        if not check(ctx.author, [ROLE_ADMIN, ROLE_MODERATOR]):
            await ctx.send(
                "I don't think you understand your position here...",
                reference=ctx.message,
                mention_author=False,
            )
            return

        try:
            if limit == "all":
                await ctx.channel.purge(limit=1000)
            elif limit == "you":
                await ctx.send(
                    "Who is _you_? ~~It better not be me...~~",
                    reference=ctx.message,
                    mention_author=False,
                )
            else:
                await ctx.channel.purge(limit=int(limit) + 1)
        except ValueError:
            await ctx.send(
                f"The `limit` parameter was not in integer or `all`."
                + "\n\n**Usage:**\n```yml\n--clear all # clears 1K messages\n"
                + "--clear 6 # clears 6 messages (not including the --clear command)\n"
                + "```"
            )


def setup(bot: commands.Bot):
    bot.add_cog(CleanupCog(bot))
