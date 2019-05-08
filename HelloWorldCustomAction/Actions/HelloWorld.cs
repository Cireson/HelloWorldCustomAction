using System;
using System.Threading.Tasks;
using Cireson.ControlCenter.Core.Actions.Base;
using Cireson.ControlCenter.Core.RsOperations.Attributes;
using Cireson.Core.Services.Actions;
using Cireson.Core.Interfaces.DataAccess;
using Cireson.Core.Common.Attributes;
using Cireson.ControlCenter.Core.Models.ConfigurationManager;

namespace HelloWorldCustomAction.Actions
{
    /// <summary>
    /// Class supports a Custom Action that is bound to CmDevice entities.
    /// </summary>
    /// <typeparam name="TEntity">The entity type to perform the bound action on.</typeparam>
    /// <example>
    /// POST http://localhost/api/{EntitySet}({EntityId)/Action.HelloWorld
    /// </example>
    [ODataAlias]
    /// <RsOperation Attribute>
    /// This attribute indicates where the custom action is going to be placed.
    /// Params ( ActionType , Custom Action Name, Bound Entity Type, Order, Group )
    ///     Action Type: Defines whether this action will be a Remote Action, Quick Action or One Click Action.
    ///     ·Remote actions will be placed under the remote manage flyout for the specified entity type.
    ///     ·Quick actions will be placed under the grid 'more actions' flyout.
    ///     ·One click actions will be placed and available as the grid row actions.
    ///     Custom Action Name: Name for your custom action.
    ///     Bound Entity Type: This is the entity set that the action will be bound to.
    ///     Order: This is the order of your custom action and it is used only for templating purposes.
    ///     Group: There are three default groups for custom actions which are RCA, QCA, OCCA and go for each type of action accordingly.
    ///     ·RCA: Remote Custom Action.
    ///     ·QCA: Quick Custom Action.
    ///     ·OCCA: One Click Custom Action.
    /// </RsOperation>
    [RsOperation(RsOperationAttribute.ActionTypes.Remote, "HelloWorld", "Cireson.ControlCenter.Core.Models.ConfigurationManager.CmDevice", 1, "RCA")]
    [RsOperation(RsOperationAttribute.ActionTypes.Quick, "HelloWorld", "Cireson.ControlCenter.Core.Models.ConfigurationManager.CmDevice", 1, "QCA")]
    [RsOperation(RsOperationAttribute.ActionTypes.OneClick, "HelloWorld", "Cireson.ControlCenter.Core.Models.ConfigurationManager.CmDevice", 1, "OCCA")]
    public class HelloWorld<TEntity> : BoundActionLoggingBase<TEntity, bool> where TEntity : CmDevice
    {
        /// <summary>
        /// Asynchronously executes a POST request from an odata client or browser.
        /// </summary>
        /// <returns>Returns the execution result.</returns>
        public override async Task<bool> ExecuteAsync()
        {
            await ActionLogger.LogActionSuccess(Entity.Name, Entity.ResourceId, this, "HelloWorld executed successfully.");
            return true;
        }
    }
}
