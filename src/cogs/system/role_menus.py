from nextcord import Message, PartialEmoji, Reaction, TextChannel, Member
from nextcord.ext import commands
from config import ROLE_ADMIN, ROLE_MODERATOR, BOT
from utils import check, load_json, save_json


class RoleMenuCog(commands.Cog):
    """Commands for creating reaction based role-menus"""

    def __init__(self, bot: commands.Bot):
        self.bot = bot

    @commands.command()
    async def rolemenu(self, ctx: commands.Context, msg_id, chnl: str, *, reaction_str):
        """
        Creates a role menu.
        ```
        --rolemenu message_id channel
        :emoji: @Role/role_id
        :emoji2: @Role2/role2_id
        ```
        """

        # Check roles
        if not check(ctx.author, [ROLE_ADMIN, ROLE_MODERATOR]):
            await ctx.send(
                "I don't think you understand your position here...",
                reference=ctx.message,
                mention_author=False,
            )
            return

        reactions = reaction_str.replace(" ", "").split("\n")
        channel_id = int(chnl.replace("<#", "").replace(">", ""))
        role_menus = load_json("role_menus")

        message: Message = await BOT.get_channel(channel_id).fetch_message(msg_id)
        if not message:
            return

        for reaction in reactions:
            reaction = reaction.split("|")
            role_id = reaction[1].replace("<@&", "").replace(">", "")
            emoji = (
                await ctx.guild.fetch_emoji(
                    int(reaction[0].split(":")[2].replace(">", ""))
                )
                if ":" in reaction[0]
                else PartialEmoji(name=reaction[0])
            )

            await message.add_reaction(emoji)

            role_menus[msg_id] = role_menus[msg_id] if msg_id in role_menus else {}
            role_menus[msg_id][emoji.id if emoji.id else emoji.name] = role_id

        save_json("role_menus", role_menus)

        await ctx.channel.send(
            "*Consider it done*",
            reference=ctx.message,
            mention_author=False,
        )

    @commands.Cog.listener()
    async def on_raw_reaction_add(self, payload) -> None:

        channel: TextChannel = await BOT.fetch_channel(payload.channel_id)
        message_id: str = str(payload.message_id)
        member: Member = channel.guild.get_member(payload.user_id)
        emoji = payload.emoji

        if member.id == BOT.user.id:
            return

        role_menus = load_json("role_menus")

        if message_id in role_menus:
            if emoji.name in role_menus[message_id]:
                role_id = role_menus[message_id][emoji.name]
            elif emoji.id in role_menus[message_id]:
                role_id = role_menus[message_id][emoji.id]
            else:
                return

            await member.add_roles(channel.guild.get_role(int(role_id)))

    @commands.Cog.listener()
    async def on_raw_reaction_remove(self, payload) -> None:

        channel: TextChannel = await BOT.fetch_channel(payload.channel_id)
        message_id: str = str(payload.message_id)
        member: Member = channel.guild.get_member(payload.user_id)
        emoji = payload.emoji

        if member.id == BOT.user.id:
            return

        role_menus = load_json("role_menus")

        if str(message_id) in role_menus:
            if emoji.name in role_menus[message_id]:
                role_id = role_menus[message_id][emoji.name]
            elif emoji.id in role_menus[message_id]:
                role_id = role_menus[message_id][emoji.id]
            else:
                return

            await member.remove_roles(channel.guild.get_role(int(role_id)))


def setup(bot: commands.Bot):
    bot.add_cog(RoleMenuCog(bot))
