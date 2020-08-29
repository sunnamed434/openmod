﻿using OpenMod.API;
using OpenMod.API.Eventing;
using OpenMod.API.Users;
using OpenMod.Unturned.Entities;
using SDG.Unturned;

namespace OpenMod.Unturned.Events.Players.Connections
{
    internal class PlayerConnectionsEventsListener : UnturnedEventsListener
    {
        public PlayerConnectionsEventsListener(IOpenModHost openModHost,
            IEventBus eventBus,
            IUserManager userManager) : base(openModHost, eventBus, userManager)
        {

        }

        public override void Subscribe()
        {
            Provider.onEnemyConnected += OnPlayerConnected;
            Provider.onEnemyDisconnected += OnPlayerDisconnected;
        }

        public override void Unsubscribe()
        {
            Provider.onEnemyConnected -= OnPlayerConnected;
            Provider.onEnemyDisconnected -= OnPlayerDisconnected;
        }

        private void OnPlayerConnected(SteamPlayer steamPlayer)
        {
            UnturnedPlayer player = GetUnturnedPlayer(steamPlayer);

            UnturnedPlayerConnectEvent @event = new UnturnedPlayerConnectEvent(player);

            Emit(@event);
        }

        private void OnPlayerDisconnected(SteamPlayer steamPlayer)
        {
            UnturnedPlayer player = GetUnturnedPlayer(steamPlayer);

            UnturnedPlayerDisconnectEvent @event = new UnturnedPlayerDisconnectEvent(player);

            Emit(@event);
        }
    }
}